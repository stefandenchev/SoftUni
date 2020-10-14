using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            var burrows = new int[4];
            int burrowCounter = 0;

            int snakeRow = 0;
            int snakeCol = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(0); col++)
                {
                    field[row, col] = currRow[col];
                    if (field[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (field[row, col] == 'B')
                    {
                        burrows[burrowCounter] = row;
                        burrows[burrowCounter + 1] = col;
                        burrowCounter += 2;
                    }
                }
            }

            int firstBurRow = burrows[0];
            int firstBurCol = burrows[1];
            int secondBurRow = burrows[2];
            int secondBurCol = burrows[3];

            bool left = false;
            int food = 0;

            while (!false && food < 10)
            {
                string command = Console.ReadLine();
                field[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    snakeRow--;
                }

                else if (command == "down")
                {
                    snakeRow++;
                }

                else if (command == "left")
                {
                    snakeCol--;
                }

                else if (command == "right")
                {
                    snakeCol++;
                }

                if (snakeRow < 0 || snakeRow >= n || snakeCol < 0 || snakeCol >= n)
                {
                    left = true;
                    break;
                }

                if (field[snakeRow, snakeCol] == '*')
                {
                    food++;
                    field[snakeRow, snakeCol] = 'S';
                }

                if (field[snakeRow, snakeCol] == 'B')
                {
                    if (field[snakeRow, snakeCol] == field[firstBurRow, firstBurCol])
                    {
                        field[snakeRow, snakeCol] = '.';
                        snakeRow = secondBurRow;
                        snakeCol = secondBurCol;
                        field[snakeRow, snakeCol] = 'S';
                    }
                    else
                    {
                        field[snakeRow, snakeCol] = '.';
                        snakeRow = firstBurRow;
                        snakeCol = firstBurCol;
                        field[snakeRow, snakeCol] = 'S';
                    }
                }
                field[snakeRow, snakeCol] = 'S';
                //PrintMatrix(field);
            }

            if (left)
            {
                Console.WriteLine("Game over!");
            }
            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {food}");
            PrintMatrix(field);
        }

        /*public static void FillMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(0); col++)
                {
                    field[row, col] = currRow[col];
                    if (field[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
        }*/

        private static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
