using System;

namespace _02.Revolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var field = new char[n, n];

            int carRow = 0;
            int carCol = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(0); col++)
                {
                    field[row, col] = currRow[col];
                    if (field[row, col] == 'f')
                    {
                        carRow = row;
                        carCol = col;
                    }
                }
            }

            bool step = false;
            bool finished = false;


            for (int i = 0; i < m; i++)
            {
                if (finished)
                {
                    break;
                }

                string command = Console.ReadLine();

                if (!step)
                {
                    field[carRow, carCol] = '-';
                }

                if (command == "up")
                {
                    carRow--;
                    if (carRow < 0)
                    {
                        carRow = n - 1;
                    }
                }

                else if (command == "down")
                {
                    carRow++;
                    if (carRow > n - 1)
                    {
                        carRow = 0;
                    }
                }

                else if (command == "left")
                {
                    carCol--;
                    if (carCol < 0)
                    {
                        carCol = n - 1;
                    }
                }

                else if (command == "right")
                {
                    carCol++;
                    if (carCol > n - 1)
                    {
                        carCol = 0;
                    }
                }

                if (field[carRow, carCol] == 'B')
                {
                    if (command == "up")
                    {
                        carRow--;
                        if (carRow < 0)
                        {
                            carRow = n - 1;
                        }
                    }

                    else if (command == "down")
                    {
                        carRow++;
                        if (carRow > n - 1)
                        {
                            carRow = 0;
                        }
                    }

                    else if (command == "left")
                    {
                        carCol--;
                        if (carCol < 0)
                        {
                            carCol = n - 1;
                        }
                    }

                    else if (command == "right")
                    {
                        carCol++;
                        if (carCol > n - 1)
                        {
                            carCol = 0;
                        }
                    }

                }


                if (field[carRow, carCol] == 'T')
                {
                    step = true;
                    if (command == "up")
                    {
                        carRow++;
                    }

                    else if (command == "down")
                    {
                        carRow--;
                    }

                    else if (command == "left")
                    {
                        carCol++;
                    }

                    else if (command == "right")
                    {
                        carCol--;
                    }
                }

                if (field[carRow, carCol] == 'F')
                {
                    finished = true;
                    field[carRow, carCol] = 'f';
                }

                //PrintMatrix(field);
            }

            field[carRow, carCol] = 'f';
            if (finished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
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
    }
}