using System;

namespace Market_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            /* When debugging, discount rate is printed, 
             * but when start the app without debugging, discount rate is 0.0%.  */
            Bronze bronzeCard = new Bronze(600, 850);
            Console.WriteLine(bronzeCard.ToString());
        }
    }
}
