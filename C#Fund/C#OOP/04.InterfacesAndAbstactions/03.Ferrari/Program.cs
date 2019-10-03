using System;

namespace _03.Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = Console.ReadLine();
            var car = new Ferrari(driver);

            Console.WriteLine($"{car.Model}/{car.Brakes()}/{car.Gas()}/{car.Driver}");
        }
    }
}
