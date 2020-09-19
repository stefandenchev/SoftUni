using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int row = 0;
            int col = 0;
            string direction = "right";
            for (int i = 0; i < n * n; i++)
            {
                matrix[row, col] = i + 1;

                if (direction == "right")
                {
                    col++;
                    if (col == n || matrix[row, col] != 0)
                    {
                        col--;
                        direction = "down";
                    }
                }
                if (direction == "down")
                {
                    row++;
                    if (row == n || matrix[row, col] != 0)
                    {
                        row--;
                        direction = "left";
                    }
                }
                if (direction == "left")
                {
                    col--;
                    if (col == -1 || matrix[row, col] != 0)
                    {
                        col++;
                        direction = "up";
                    }
                }
                if (direction == "up")
                {
                    row--;
                    if (row == -1 || matrix[row, col] != 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                }

            }
            PrintMatrix(matrix);
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 10)
                    {
                        Console.Write(" " + matrix[row, col] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}