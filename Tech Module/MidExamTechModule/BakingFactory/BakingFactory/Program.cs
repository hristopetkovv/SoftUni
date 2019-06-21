using System;
using System.Collections.Generic;
using System.Linq;

namespace BakingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var bestQuality = int.MinValue;
            var bestList = new List<int>();
            var bestArray = bestList.ToArray();
            var bestLenght = 0;

            while (true)
            {
                input = Console.ReadLine();

                if(input=="Bake It!")
                {
                    break;
                }

                var array = input.Split("#")
                    .Select(int.Parse)  
                    .ToArray();

                var quality = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    quality += array[i];
                }
                if (quality == bestQuality)
                {
                    if(array.Length<bestArray.Length)
                    {
                        bestQuality = quality;
                        bestLenght = array.Length;
                        bestArray = array;
                    }
                    else
                    {
                        continue;
                    }
                }
                if(quality>bestQuality)
                {
                    bestQuality = quality;
                    bestLenght = array.Length;
                    bestArray = array;
                }

            }
            Console.WriteLine($"Best Batch quality: {bestQuality}");
            Console.WriteLine(string.Join(" ",bestArray));
        }
    }
}
