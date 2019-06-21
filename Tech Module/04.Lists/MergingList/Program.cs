using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            int minCount = Math.Min(firstNumbers.Count, secondNumbers.Count);

            for(int i=0;i<minCount;i++)
            {
                result.Add(firstNumbers[i]);
                result.Add(secondNumbers[i]);
            }

            List<int> BiggerList;
            if (minCount == firstNumbers.Count)
            {
                BiggerList = secondNumbers;
            }
            else
            {
                BiggerList = firstNumbers;
            }

            for(int i=minCount;i<BiggerList.Count;i++)
            {
                result.Add(BiggerList[i]);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
