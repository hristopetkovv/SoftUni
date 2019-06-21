using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> secondHand = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            for(int i=0;i<firstHand.Count;i++)
            {

                for(int j=0;j<secondHand.Count;j++)
                {
                    if(firstHand[i]>secondHand[j])
                    {
                        int firstNumber = firstHand[0];
                        firstHand.RemoveAt(0);
                        firstHand.Add(firstNumber);
                        firstHand.Add(secondHand[j]);
                    }

                    else if(firstHand[i]<secondHand[i])
                    {
                        int firstNumber = secondHand[0];
                        secondHand.RemoveAt(0);
                        secondHand.Add(firstNumber);
                        secondHand.Add(firstHand[i]);
                    }

                    else if(firstHand[i]==secondHand[j])
                    {
                        firstHand.RemoveAt(firstHand[i]);
                        secondHand.RemoveAt(secondHand[j]);
                    }

                    if(firstHand.Count==0)
                    {
                        foreach(var x in secondHand)
                        {
                            sum += x;
                        }

                        Console.WriteLine($"First Player wins!");
                    }

                    else if(secondHand.Count==0)
                    {
                        foreach(var x in firstHand)
                        {
                            sum += x;
                        }
                        Console.WriteLine($"Second Player wins! Sum:{sum}");
                        
                    }
                }
            }
        }
    }
}
