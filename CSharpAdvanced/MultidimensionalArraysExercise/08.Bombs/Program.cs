﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            FillMatrix(matrix);

            string[] input = Console.ReadLine().Split();
            List<string> bombCoordinates = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                bombCoordinates.Add(input[i]);
            }

            int counter = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    var elements = bombCoordinates[counter].Split(",").ToArray();
                    int currentBombRow = int.Parse(elements[0]);
                    int currentBombCol = int.Parse(elements[1]);

                    if (row == currentBombRow && col == currentBombCol && matrix[currentBombRow, currentBombCol] > 0)
                    {
                        if (row - 1 >= 0 && col - 1 >= 0 && row - 1 < n && col - 1 < n)
                        {
                            if (matrix[row - 1, col - 1] > 0)
                            {
                                matrix[row - 1, col - 1] -= matrix[row, col];
                            }
                        }

                        if (row - 1 >= 0 && col >= 0 && row - 1 < n && col < n)
                        {
                            if (matrix[row - 1, col] > 0)
                            {
                                matrix[row - 1, col] -= matrix[row, col];
                            }
                        }

                        if (row - 1 >= 0 && col + 1 >= 0 && row - 1 < n && col + 1 < n)
                        {
                            if (matrix[row - 1, col + 1] > 0)
                            {
                                matrix[row - 1, col + 1] -= matrix[row, col];
                            }
                        }

                        if (row >= 0 && col - 1 >= 0 && row < n && col - 1 < n)
                        {
                            if (matrix[row, col - 1] > 0)
                            {
                                matrix[row, col - 1] -= matrix[row, col];
                            }
                        }

                        if (row >= 0 && col + 1 >= 0 && row < n && col + 1 < n)
                        {
                            if (matrix[row, col + 1] > 0)
                            {
                                matrix[row, col + 1] -= matrix[row, col];
                            }
                        }

                        if (row + 1 >= 0 && col - 1 >= 0 && row + 1 < n && col - 1 < n)
                        {
                            if (matrix[row + 1, col - 1] > 0)
                            {
                                matrix[row + 1, col - 1] -= matrix[row, col];
                            }
                        }

                        if (row + 1 >= 0 && col >= 0 && row + 1 < n && col - 1 < n)
                        {
                            if (matrix[row + 1, col] > 0)
                            {
                                matrix[row + 1, col] -= matrix[row, col];
                            }
                        }

                        if (row + 1 >= 0 && col + 1 >= 0 && row + 1 < n && col + 1 < n)
                        {
                            if (matrix[row + 1, col + 1] > 0)
                            {
                                matrix[row + 1, col + 1] -= matrix[row, col];
                            }
                        }
                        matrix[row, col] = 0;
                        counter++;
                    }
                    if (bombCoordinates.Contains(int.Parse(row)))
                    {

                    }
                }

            }
            PrintMatrix(matrix);
        }

        private static void FillMatrix(int[,] numbers)
        {
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    numbers[row, col] = currentRow[col];
                }
            }
        }
        private static void PrintMatrix(int[,] numbers)
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