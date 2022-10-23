public class Son
{
    public void DadGiveCar(Car car)
    {
        Console.WriteLine("Czekam aż stary pójdzie spać");
        Thread.Sleep(500);
        Console.WriteLine("Stary poszedł spać");
        car.StartStop();
        Thread.Sleep(500);
        car.StartStop();
        Console.WriteLine("Oddajemy kluczyki");
        Console.WriteLine(new String('-',30));
    }
}