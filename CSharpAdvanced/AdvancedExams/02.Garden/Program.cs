using System;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split();
            int n = int.Parse(dimensions[0]);
            int m = int.Parse(dimensions[1]);

            int[,] matrix = new int[n, m];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            string input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                var elements = input.Split();
                int flowerRow = int.Parse(elements[0]);
                int flowerCol = int.Parse(elements[1]);

                if (flowerRow < 0 || flowerRow > matrix.GetLength(0) || flowerCol < 0 || flowerCol > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    input = Console.ReadLine();
                    continue;
                }

                else
                {
                    matrix[flowerRow, flowerCol]++;
                    for (int row = flowerRow - 1; row >= 0; row--)
                    {
                        matrix[row, flowerCol]++;
                    }

                    for (int col = flowerCol - 1; col >= 0; col--)
                    {
                        matrix[flowerRow, col]++;
                    }

                    for (int row = flowerRow + 1; row < m; row++)
                    {
                        matrix[row, flowerCol]++;
                    }

                    for (int col = flowerRow + 1; col < m; col++)
                    {
                        matrix[flowerRow, col]++;
                    }
                }

                input = Console.ReadLine();

            }

            Print(matrix);
        }



        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}