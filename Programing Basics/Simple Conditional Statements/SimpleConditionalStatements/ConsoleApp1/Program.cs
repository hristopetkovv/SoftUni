using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthA = double.Parse(Console.ReadLine());
            double heightB = double.Parse(Console.ReadLine());
            double wallArea = widthA * (widthA / 2) * 2;
            double backWallArea = (widthA / 2) * (widthA / 2) + (widthA / 2) * (heightB - widthA / 2) / 2;
            double frontWallArea = backWallArea - (widthA / 5) * (widthA / 5);
            double roof = widthA * (widthA / 2) * 2;
            double greenColor = (wallArea + backWallArea + frontWallArea) / 3;
            double redColor = roof / 5;
            Console.WriteLine("{0:f2}", greenColor);
            Console.WriteLine("{0:f2}", redColor);
        }
    }
}
