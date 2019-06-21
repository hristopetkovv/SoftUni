using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftandRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftsum = 0;
            for(int i=0;i<n;i++)
            {
                leftsum = leftsum + int.Parse(Console.ReadLine());
            }
            int rightsum = 0;
            for(int i=0;i<n;i++)
            {
                rightsum = rightsum + int.Parse(Console.ReadLine());
            }
            if(leftsum==rightsum)
            {

                Console.WriteLine("Yes, sum = " +leftsum);
            }
            else
            {
                Console.WriteLine("No, diff = " + Math.Abs(rightsum-leftsum));
            }

        }
    }
}
