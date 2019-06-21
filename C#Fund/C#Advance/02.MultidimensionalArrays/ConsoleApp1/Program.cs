namespace MaximalSum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];

            int[,] matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowNumbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowNumbers[col];
                }
            }

            int rowOfSubMatrix = -1;
            int colOfSubMatrix = -1;
            int biggestSum = int.MinValue;
            for (int row = 0; row < matrixRows - 2; row++)
            {
                for (int col = 0; col < matrixCols - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                   + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                   + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        rowOfSubMatrix = row;
                        colOfSubMatrix = col;
                    }
                }
            }
            Console.WriteLine("Sum = " + biggestSum);
            for (int row = rowOfSubMatrix; row < rowOfSubMatrix + 3; row++)
            {
                for (int col = colOfSubMatrix; col < colOfSubMatrix + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}