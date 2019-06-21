using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int parisEnergy = int.Parse(Console.ReadLine());

            int n = int.Parse(Console.ReadLine());

            char[][] room = new char[n][];

            int parisRow = -1;
            int parisCol = -1;

            int helanRow = -1;
            int helanCol = -1;         

            for (int i = 0; i < n; i++)
            {                
                room[i] = Console.ReadLine().ToCharArray();
                if (room[i].Contains('P'))
                {
                    int index = Array.IndexOf(room[i], 'P');
                    parisRow = i;
                    parisCol = index;
                    room[parisRow][parisCol] = 'P';
                }
                else if (room[i].Contains('H'))
                {
                    int index = Array.IndexOf(room[i], 'H');
                    helanRow = i;
                    helanCol = index;
                    room[helanRow][helanCol] = 'H';
                }
            }
            while (parisEnergy > 0 || room[parisRow][parisCol] == room[helanRow][helanCol])
            {
                string[] commands = Console.ReadLine().Split(' ');

                room[parisRow][parisCol] = '-';
                string command = commands[0];
                switch (command)
                {
                    case "up":
                        parisRow--;
                        break;
                    case "down":
                        parisRow++;
                        break;
                    case "left":
                        parisCol--;
                        break;
                    case "right":
                        parisCol++;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < room.Length; i++)
                {
                    int rowLength = room[i].Length;
                    
                    if (room[i].Contains('P') && Array.IndexOf(room[i], 'P') == rowLength)
                    {
                        room[i][rowLength - 1] = 'P';

                    }
                    else if (room[i].Contains('P') && Array.IndexOf(room[i], 'P') == rowLength-rowLength-1)
                    {
                        room[i][0] = 'P';
                    }
                }

                int spawnEnemyRow = int.Parse(commands[1]);

                int spawnEnemyCol = int.Parse(commands[2]);

                room[spawnEnemyRow][spawnEnemyCol] = 'S';

                if(room[parisRow][parisCol] != room[spawnEnemyRow][spawnEnemyCol])
                {
                    parisEnergy -= 1;
                }
                else //if (room[parisRow][parisCol] == room[spawnEnemyRow][spawnEnemyCol])
                {
                    parisEnergy -= 2;

                    //if (parisEnergy <= 0)
                    //{
                        room[spawnEnemyRow][spawnEnemyCol] = 'X';
                        Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
                    break;
                   // }
                    //if()
                    //{
                    //    room[spawnEnemyRow][spawnEnemyCol] = 'P';
                    //    parisEnergy -= 2;
                    //}
                } 
                
                if(room[parisRow][parisCol] == room[helanRow][helanCol])
                {
                    room[parisRow][parisCol] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
                    break;
                }
            }

            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
