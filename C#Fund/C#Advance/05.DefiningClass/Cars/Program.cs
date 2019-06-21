using System;

namespace Cars
{
    public class Program
    {
        public static void Main()
        {
            var engine = new Engine(400, 4.8);

            var car = new Car("Mercedes", "S500", engine, 2010, 0, 15);

            Console.WriteLine(car.GetInformation());
        }
    }
}
