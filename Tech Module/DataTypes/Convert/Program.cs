using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert
{
    class Program
    {
        static void Main(string[] args)
        {
            double distanceInMeter = double.Parse(Console.ReadLine());
            double distanceInKm = distanceInMeter / 1000;
            Console.WriteLine("{0:f2}",distanceInKm);
        }
    }
}
