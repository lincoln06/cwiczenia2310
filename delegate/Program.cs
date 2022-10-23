var car = new Car();
var son = new Son();
var dad = new Dad(car, son);
dad.Life();

public class Car
{
    private bool _isOn;
    List<ICarNotification> carNotifications = new List<ICarNotification>();
    public void StartStop()
    {
        if (!_isOn)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("brr........");

                Thread.Sleep(500);
            }
            Console.WriteLine("brrrrrrrrrrr");
            _isOn = true;
            foreach (var item in carNotifications)
            {
                item.Notify($"{DateTime.Now} silnik odpalony");
            }
            Console.WriteLine("Krzychu kadetem tera!!!!!!!!!!!!!!1");
            foreach (var item in carNotifications)
            {
                item.Notify($"{DateTime.Now} silnik wyłączony");
            }
            return;
        }
        Console.WriteLine("Wyłączono silnik");
        _isOn = false;
    }
    public void Add(ICarNotification carNotification)
    {
        carNotifications.Add(carNotification);
    }
    public void Remove(ICarNotification carNotification)
    {
        carNotifications.Remove(carNotification);
    }
}
public class Dad
{
    private readonly Car _car;
    private readonly Son _son;
    public Dad(Car car, Son son)
    {
        _car = car;
        _son = son;
    }
    public void Life()
    {
        Thread.Sleep(3000);
        SmsSend sms = new SmsSend();
        EmailSend mail = new EmailSend();
        _car.Add(sms);
        _car.Add(mail);
        _son.DadGiveCar(_car);
        _car.Remove(sms);
        _car.Remove(mail);
        _car.StartStop();
    }
}
public class SmsSend : ICarNotification
{
    public void Notify(string message)
    {
        Console.WriteLine($"Wysyłam sms o treści {message}");
    }
}
public class EmailSend : ICarNotification
{
    public void Notify(string message)
    {
        Console.WriteLine($"Wysyłam mail o treści {message}");
    }
}
public interface ICarNotification
{
    void Notify(string message);
}