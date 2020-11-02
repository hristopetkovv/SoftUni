using System;

namespace Market_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle t = new Circle();

            t.Width = 5;
            t.Height = 6;
            Console.WriteLine(t.CalculateSurface());
        }
    }
}
