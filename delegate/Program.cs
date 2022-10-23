var car = new Car();
var son = new Son();
var dad = new Dad(car, son);
dad.Life();

public class Car
{
    public event CarNotifyDelegate CarNotifyDelegate;
    private bool _isOn;
    
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
            //foreach (var item in carNotifyDelegate.GetInvocationList())
            //{
            //    item.DynamicInvoke($"{DateTime.Now} silnik odpalony");
            //}
            CarNotifyDelegate?.Invoke($"{DateTime.Now} silnik odpalony");
            //Console.WriteLine("Krzychu kadetem tera!!!!!!!!!!!!!!1");
            //foreach (var item in carNotifyDelegate.GetInvocationList())
            //{
            //    item.DynamicInvoke($"{DateTime.Now} silnik wyłączony");
            //}
            CarNotifyDelegate?.Invoke($"{DateTime.Now} silnik wyłączony");
            return;
        }
        Console.WriteLine("Wyłączono silnik");
        _isOn = false;
    }
    //public void Add(CarNotifyDelegate carNotification)
    //{
    //    carNotifyDelegate+=carNotification;
    //}
    //public void Remove(CarNotifyDelegate carNotification)
    //{
    //    carNotifyDelegate -= carNotification;
    //}
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
        //var smsDelegate = new CarNotifyDelegate(NotifySms);
        //var emailDelegate = new CarNotifyDelegate(NotifyMail);
        _car.CarNotifyDelegate+=(str => Console.WriteLine($"Wysyłam sms o treści {str}") );

        _car.CarNotifyDelegate += NotifySms;
        _car.CarNotifyDelegate+=NotifyMail;

        _son.DadGiveCar(_car);
        _car.CarNotifyDelegate-=NotifySms;
        _car.CarNotifyDelegate-=NotifyMail;
        //_car.StartStop();
        int[] array=new int[] {1,2,3,4,5,6,7,8,9,10};
        array.Where(x => x % 2 == 0);
    }
    private void NotifySms(string message)
    {
        Console.WriteLine($"Wysyłam sms o treści {message}");
    }
    private void NotifyMail(string message)
    {
        Console.WriteLine($"Wysyłam sms o treści {message}");
    }
}
public delegate void CarNotifyDelegate(string str);
//public class SmsSend : ICarNotification
//{
//    public void Notify(string message)
//    {
//        Console.WriteLine($"Wysyłam sms o treści {message}");
//    }
//}
//public class EmailSend : ICarNotification
//{
//    public void Notify(string message)
//    {
//        Console.WriteLine($"Wysyłam mail o treści {message}");
//    }
//}
//public interface ICarNotification
//{
//    void Notify(string message);
//}