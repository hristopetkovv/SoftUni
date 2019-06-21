using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000DaysAfterBirth
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            DateTime data2 = data.AddDays(999);
            Console.WriteLine(data2.ToString("dd-MM-yyyy"));
        }
    }
}
