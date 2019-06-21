using System;
using System.Collections.Generic;
using System.Linq;

namespace P05SNake
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions=Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] matrix = new char[rows][];

            var snakeStr = Console.ReadLine().ToCharArray();

            Queue<char> SnakeQueue = new Queue<char>(snakeStr);

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                for (int col = 0; col < cols; col++)
                {
                    char charToAdd = SnakeQueue.Dequeue();
                    matrix[row][col] = charToAdd;
                    SnakeQueue.Enqueue(charToAdd);
                }
            }
            Console.WriteLine(String.Join(Environment.NewLine,matrix.Select(r=>string.Join("",r))));


        }
    }
}
