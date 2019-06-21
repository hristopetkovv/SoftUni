using System;
using System.Collections.Generic;
using System.Linq;

namespace MeTubeAssociative
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> videos = new Dictionary<string, int[]>();

            string input = Console.ReadLine();

            while (input != "stats time") 
            {
                if(input.Contains('-'))
                {
                    string[] tokens = input.Split('-');
                    string name = tokens[0];
                    int views = int.Parse(tokens[1]);

                    if(!videos.ContainsKey(name))
                    {
                        videos[name] = new int[2];  //ako go nqma go dobavq
                    }

                    videos[name][0] += views;
                }
                else if(input.Contains(":"))
                {
                    string[] tokens = input.Split(":");
                    string like = tokens[0];
                    string name = tokens[1];

                    if(videos.ContainsKey(name))
                    {
                        if (like == "like")
                        {
                            videos[name][1]++;
                        }
                        else if(like=="dislike")
                        {
                            videos[name][1]--;
                        }
                    }
                }

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            
            if(input=="by views")
            {
                foreach (var video in videos.OrderByDescending(v=>v.Value[0]))
                {
                    string name = video.Key;
                    int views = video.Value[0];
                    int likes = video.Value[1];
                    Console.WriteLine($"{name} - {views} views - {likes} likes");
                }
            }
            else if(input=="by likes")
            {
                foreach (var video in videos.OrderByDescending(v => v.Value[1]))
                {
                    string name = video.Key;
                    int views = video.Value[0];
                    int likes = video.Value[1];
                    Console.WriteLine($"{name} - {views} views - {likes} likes");
                }
            }
        }
    }
}
