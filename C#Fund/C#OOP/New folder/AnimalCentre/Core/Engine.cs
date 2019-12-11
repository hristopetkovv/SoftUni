namespace AnimalCentre.Core
{
    using global::AnimalCentre.Core.Contracts;

    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        public void Run()
        {
            //read console
            //pass animal centre
            //print console
            //catch exception
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string command = inputArgs[0];
                    string[] args = inputArgs.Skip(1).ToArray();

                    input = Console.ReadLine();
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
        }
    }
}
