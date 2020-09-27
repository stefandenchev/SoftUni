using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            List<int[]> bunnies = new List<int[]>();
            var matrix = new char[rows, cols];
            FillMatrix(matrix);

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            var directionsArr = Console.ReadLine().ToCharArray();
            Queue<char> directions = new Queue<char>(directionsArr);
            bool dead = false;
            bool won = false;

            while (true)
            {
                char direction = directions.Dequeue();

                if (direction == 'U')
                {
                    if (!(playerRow - 1 < 0))
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow--;
                        matrix[playerRow, playerCol] = 'P';

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        won = true;
                    }

                }


                if (direction == 'D')
                {
                    if (!(playerRow + 1 > rows - 1))
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerRow++;
                        matrix[playerRow, playerCol] = 'P';

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        won = true;
                    }

                }

                if (direction == 'R')
                {
                    if (!(playerCol + 1 > cols - 1))
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol++;
                        matrix[playerRow, playerCol] = 'P';

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        won = true;
                    }

                }


                if (direction == 'L')
                {
                    if (!(playerCol - 1 < 0))
                    {
                        matrix[playerRow, playerCol] = '.';
                        playerCol--;
                        matrix[playerRow, playerCol] = 'P';

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {playerRow} {playerCol}");
                            return;
                        }

                    }

                    else
                    {
                        matrix[playerRow, playerCol] = '.';
                        won = true;
                    }

                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            int[] currentBunny = { row, col };
                            if (!bunnies.Contains(currentBunny))
                            {
                                bunnies.Add(currentBunny);
                            }
                        }
                    }
                }

                for (int i = 0; i < bunnies.Count; i++)
                {
                    int[] currentBunny = bunnies[i];
                    int row = currentBunny[0];
                    int col = currentBunny[1];


                    if (matrix[row, col] == 'B')
                    {
                        if (!(row - 1 < 0))
                        {
                            if (matrix[row - 1, col] == 'P')
                            {
                                dead = true;
                            }
                            matrix[row - 1, col] = 'B';
                        }

                        if (!(row + 1 > rows - 1))
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                dead = true;
                            }
                            matrix[row + 1, col] = 'B';
                        }

                        if (!(col - 1 < 0))
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                dead = true;
                            }
                            matrix[row, col - 1] = 'B';
                        }

                        if (!(col + 1 > cols - 1))
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                dead = true;
                            }
                            matrix[row, col + 1] = 'B';
                        }

                    }
                    else if (matrix[row, col] == 'P')
                    {
                        matrix[row, col] = 'B';
                        dead = true;
                    }
                }

                if (dead)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
                if (won)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }
            }

        }

        private static void FillMatrix(char[,] numbers)
        {
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
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
                    Console.Write(numbers[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}