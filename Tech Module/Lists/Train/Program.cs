using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> NumberOfPassengersInEachWagon = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int MaxCapacityOfEachWagon = int.Parse(Console.ReadLine());

            while(true)
            {
                string Input = Console.ReadLine();

                if(Input=="end")
                {
                    break;
                }

                string[] tokens = Input.Split();

                string command = tokens[0];

                if(command=="Add")
                {
                    int passengersToAdd = int.Parse(tokens[1]);
                    NumberOfPassengersInEachWagon.Add(passengersToAdd);
                    
                }

                else
                {
                    int passengersToAdd = int.Parse(tokens[0]);
                    
                    NumberOfPassengersInEachWagon.Insert(0, passengersToAdd);                  

                    for(int i=0;i<NumberOfPassengersInEachWagon.Count;i++)
                    {
                        if(NumberOfPassengersInEachWagon[i]>MaxCapacityOfEachWagon)
                        {
                            
                            int sum = NumberOfPassengersInEachWagon[i] - MaxCapacityOfEachWagon;
                            NumberOfPassengersInEachWagon[i + 1] = NumberOfPassengersInEachWagon[i + 1] + sum;
                            NumberOfPassengersInEachWagon[i] = MaxCapacityOfEachWagon;
                          
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ",NumberOfPassengersInEachWagon));
            
        }
    }
}
