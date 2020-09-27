using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var matrix = new char[n, n];
            FillMatrix(matrix);

            int coalFound = 0;
            int coalCount = 0;
            coalCount = CoalCount(n, matrix, coalCount);

            int minerRow = 0;
            int minerCol = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    
                }
            }

            var directionsArr = input.Split();
            Queue<string> directions = new Queue<string>(directionsArr);

            bool end = false;

            while (true)
            {
                string currDirection = directions.Dequeue();
                if (directions.Count == 0)
                {
                    end = true;
                }

                if (currDirection == "up")
                {
                    if (!(minerRow - 1 < 0))
                    {
                        minerRow--;
                        if (matrix[minerRow,minerCol] == 'c')
                        {
                            coalFound++;
                            matrix[minerRow, minerCol] = '*';
                            if (coalCount == coalFound)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }

                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }

                    }
                }


                if (currDirection == "down")
                {
                    if (!(minerRow + 1 > n - 1))
                    {
                        minerRow++;
                        if (matrix[minerRow, minerCol] == 'c')
                        {
                            coalFound++;
                            matrix[minerRow, minerCol] = '*';
                            if (coalCount == coalFound)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                if (currDirection == "right")
                {
                    if (!(minerCol + 1 > n - 1))
                    {
                        minerCol++;
                        if (matrix[minerRow, minerCol] == 'c')
                        {
                            coalFound++;
                            matrix[minerRow, minerCol] = '*';
                            if (coalCount == coalFound)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                if (currDirection == "left")
                {
                    if (!(minerCol - 1 < 0))
                    {
                        minerCol--;
                        if (matrix[minerRow, minerCol] == 'c')
                        {
                            coalFound++;
                            matrix[minerRow, minerCol] = '*';
                            if (coalCount == coalFound)
                            {
                                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                                return;
                            }
                        }
                        else if (matrix[minerRow, minerCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                            return;
                        }
                    }
                }

                if (end)
                {
                    int coalsLeft = coalCount - coalFound;
                    Console.WriteLine($"{coalsLeft} coals left. ({minerRow}, {minerCol})");
                    return;
                }

            }

        }

        private static int CoalCount(int n, char[,] matrix, int coalCount)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[col, row] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            return coalCount;
        }

        private static void FillMatrix(char[,] numbers)
        {
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    numbers[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintMatrix(char[,] numbers)
        {
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    Console.Write(numbers[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}