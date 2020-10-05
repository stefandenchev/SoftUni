using System;
using System.Linq;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int beeRow = 0;
            int beeCol = 0;
            int count = 0;
            bool lost = false;


            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currentRow[col];
                    if (field[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {

                if (lost)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }


                if (input == "up")
                {
                    if (beeRow - 1 < 0)
                    {
                        lost = true;
                        field[beeRow, beeCol] = '.';
                    }
                    else
                    {
                        field[beeRow, beeCol] = '.';
                        beeRow -= 1;
                        if (field[beeRow, beeCol] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            if (beeRow - 1 < 0)
                            {
                                lost = true;
                                field[beeRow, beeCol] = '.';
                            }
                            else
                            {
                                beeRow -= 1;
                            }
                        }
                    }
                }

                if (input == "down")
                {
                    if (beeRow + 1 >= n)
                    {
                        lost = true;
                        field[beeRow, beeCol] = '.';
                    }
                    else
                    {
                        field[beeRow, beeCol] = '.';
                        beeRow += 1;
                        if (field[beeRow, beeCol] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            if (beeRow + 1 >= n)
                            {
                                lost = true;
                                field[beeRow, beeCol] = '.';
                            }
                            else
                            {
                                beeRow += 1;
                            }
                        }
                    }
                }

                if (input == "left")
                {
                    if (beeCol - 1 < 0)
                    {
                        lost = true;
                        field[beeRow, beeCol] = '.';
                    }
                    else
                    {
                        field[beeRow, beeCol] = '.';
                        beeCol -= 1;
                        if (field[beeRow, beeCol] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            if (beeCol - 1 < 0)
                            {
                                lost = true;
                                field[beeRow, beeCol] = '.';
                            }
                            else
                            {
                                beeCol -= 1;
                            }
                        }
                    }
                }


                if (input == "right")
                {
                    if (beeCol + 1 >= n)
                    {
                        lost = true;
                        field[beeRow, beeCol] = '.';
                    }
                    else
                    {
                        field[beeRow, beeCol] = '.';
                        beeCol += 1;
                        if (field[beeRow, beeCol] == 'O')
                        {
                            field[beeRow, beeCol] = '.';
                            if (beeCol + 1 >= n)
                            {
                                lost = true;
                                field[beeRow, beeCol] = '.';
                            }
                            else
                            {
                                beeCol += 1;
                            }
                        }
                    }
                }

                if (field[beeRow, beeCol] == 'f')
                {
                    field[beeRow, beeCol] = '.';
                    count++;
                }

                if (!lost)
                {
                    input = Console.ReadLine();
                }
            }

            if (!lost)
            {
                field[beeRow, beeCol] = 'B';
            }
            if (count >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {count} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - count} flowers more");
            }
            PrintMatrix(field);


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
    }
}