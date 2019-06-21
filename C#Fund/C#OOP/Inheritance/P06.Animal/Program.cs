using System;
using System.Collections.Generic;

namespace P06.Animal
{
    public class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();

            while (true)
            {
                var typeCommand = Console.ReadLine();

                if (typeCommand == "Beast!")
                {
                    foreach (var animal in animals)
                    {
                        Console.WriteLine(animal);
                    }

                    break;
                }

                var argsCommand = Console.ReadLine().Split();

                var name = argsCommand[0];
                int age = int.Parse(argsCommand[1]);
                var gender = argsCommand[2];

                try
                {
                    switch (typeCommand)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;

                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;

                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;

                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;

                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
