using System;


namespace CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = celsius * 1.8000 + 32.00;
            Console.WriteLine(Math.Round(fahrenheit, 2));
        }
    }
}
