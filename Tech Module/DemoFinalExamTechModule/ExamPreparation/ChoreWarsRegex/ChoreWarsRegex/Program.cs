using System;
using System.Text.RegularExpressions;

namespace ChoreWarsRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeDishes = 0;
            int timeCleaning = 0;
            int timeLaundry = 0;
            int totalTime = 0;

            string dishesPattern = @"<([a-z\d]+)>";
            string cleaningPattern = @"\[([A-Z\d]+)\]";
            string  laundryPattern = @"\{(.*)\}";

            string input = Console.ReadLine();

            while (input != "wife is happy") 
            {
                var dishesMatch = Regex.Match(input, dishesPattern);
                var cleaningMatch = Regex.Match(input, cleaningPattern);
                var laundryMatch = Regex.Match(input, laundryPattern);

                if(dishesMatch.Success)
                {
                    string dishesStr = dishesMatch.ToString();
                    string numPattern = @"\d";

                    MatchCollection nums = Regex.Matches(dishesStr, numPattern);

                    foreach (var match in nums)
                    {
                        int num = int.Parse(match.ToString());
                        timeDishes += num;
                    }
                }
                else if(cleaningMatch.Success)
                {
                    string cleaningStr = cleaningMatch.ToString();
                    string numPattern = @"\d";

                    MatchCollection nums = Regex.Matches(cleaningStr, numPattern);

                    foreach (var match in nums)
                    {
                        int num = int.Parse(match.ToString());
                        timeCleaning += num;
                    }
                }
                else if(laundryMatch.Success)
                {
                    string laundryStr = laundryMatch.ToString();
                    string numPattern = @"\d";

                    MatchCollection nums = Regex.Matches(laundryStr, numPattern);

                    foreach (var match in nums)
                    {
                        int num = int.Parse(match.ToString());
                        timeLaundry += num;
                    }
                }

                input = Console.ReadLine();
            }
            totalTime = timeCleaning + timeDishes + timeLaundry;
            Console.WriteLine($"Doing the dishes - {timeDishes} min.");
            Console.WriteLine($"Cleaning the house - {timeCleaning} min.");
            Console.WriteLine($"Doing the laundry - {timeLaundry} min.");
            Console.WriteLine($"Total - {totalTime} min.");
        }
    }
}
 if(symbol.Length==16)
                {
                    symbol.Insert(4, "-");
                    symbol.Insert(9, "-");
                    symbol.Insert(14, "-");
                     
                }
                else if(symbol.Length==25)
                {
                    symbol.Insert(5, "-");
                    symbol.Insert(11, "-");
                    symbol.Insert(17, "-");
                    symbol.Insert(23, "-");
                }