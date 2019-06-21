using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaofFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string fig = Console.ReadLine();
            double size = double.Parse(Console.ReadLine());
            double area;
            if (fig == "square")
            {
                area = size * size;
                Console.WriteLine(Math.Round(area, 3));


            }
            else if (fig == "rectangle")
            {
                double size2 = double.Parse(Console.ReadLine());
                area = size * size2;
                Console.WriteLine(Math.Round(area, 3));

            }
            else if (fig == "circle")
            {
                area = size * size * Math.PI;
                Console.WriteLine(Math.Round(area, 3));
            }
            else if (fig == "triangle")
            {
                double height = double.Parse(Console.ReadLine());
                area = (size * height)/ 2;
                Console.WriteLine(Math.Round(area, 3));
            }
            

        }
    }
}
