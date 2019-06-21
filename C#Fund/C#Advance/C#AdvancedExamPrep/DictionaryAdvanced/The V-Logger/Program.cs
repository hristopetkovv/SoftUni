using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();

            //Pesho followed by ....
            var userFollowers = new Dictionary<string, HashSet<string>>();

            //pesho is following ....
            var userFollowing = new Dictionary<string, HashSet<string>>();

            while(true)
            {
                string input = Console.ReadLine();

                if(input== "Statistics")
                {
                    break;
                }
                string[] splitedInput = input.Split();

                if(splitedInput.Length==4)
                {
                    string username = splitedInput[0];
                    usernames.Add(username);
                    userFollowers.Add(username, new HashSet<string>()); // 2 nachina za inicializaciq
                    userFollowing[username] = new HashSet<string>();

                }
                else
                {
                    string heFollows = splitedInput[0];
                    string followed = splitedInput[2];

                    if(usernames.Contains(heFollows) && usernames.Contains(followed) && heFollows != followed)
                    {
                        userFollowers[followed].Add(heFollows);
                        userFollowing[heFollows].Add(followed);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of { usernames.Count} vloggers in its logs.");

            var topUser = userFollowers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => userFollowing[x.Key].Count())
                .FirstOrDefault();

            Console.WriteLine($"1. {topUser.Key} : {topUser.Value.Count} followers, {userFollowing[topUser.Key].Count} following");
            foreach (var username in topUser.Value.OrderBy(x => x))
            {
                Console.WriteLine($"*  {username}");
            }

            int count = 2;

            foreach (var kvp in userFollowers.Where(x=>x.Key != topUser.Key))
            {

                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value.Count} followers, {userFollowing[kvp.Key].Count} following");

                count++;
            }

        }
    }
}
