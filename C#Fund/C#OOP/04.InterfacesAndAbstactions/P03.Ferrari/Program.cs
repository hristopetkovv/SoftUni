using System;

namespace P03.Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}
