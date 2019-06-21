using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsFirst = int.Parse(Console.ReadLine());
            int secondsSecond = int.Parse(Console.ReadLine());
            int secondsThird = int.Parse(Console.ReadLine());
            int totalSeconds = secondsFirst + secondsSecond + secondsThird;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (seconds < 10)
            {
                Console.WriteLine("{0}:0{1}", minutes, seconds);
            }
            else
                Console.WriteLine("{0}:{1}", minutes, seconds);

        }
    }
}
