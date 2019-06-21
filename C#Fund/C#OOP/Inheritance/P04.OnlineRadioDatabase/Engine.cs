using P04.OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.OnlineRadioDatabase
{
    public class Engine
    {
        private List<Song> playList;

        public Engine()
        {
            this.playList = new List<Song>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split(';');

                    if(input.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    string artistName = input[0];
                    string songName = input[1];
                    var length = input[2].Split(':');

                    if (!int.TryParse(length[0], out int minutes) || !int.TryParse(length[1], out int seconds))
                    {
                        throw new InvalidSongLengthException();
                    }

                    var song = new Song(artistName, songName, minutes, seconds);
                    playList.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            int totalSeconds = playList.Sum(s => (s.Minutes * 60) + s.Seconds);
            TimeSpan duration = TimeSpan.FromSeconds(totalSeconds);
            Console.WriteLine($"Songs added: {playList.Count}");
            Console.WriteLine($"Playlist length: {duration.Hours}h {duration.Minutes}m {duration.Seconds}s");
        }
    }
}
