using System;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var websites = Console.ReadLine().Split();

            var smartphone = new Smartphone();

            foreach(var number in numbers)
            {
                Console.WriteLine(smartphone.Call(number));
            }

            foreach (var website in websites)
            {
                Console.WriteLine(smartphone.Browse(website));
            }
        }
    }
}
