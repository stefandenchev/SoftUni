using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            FillMatrix(matrix);

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                if (!validateCommand(command, rows, cols))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else
                {
                    string[] commands = command.Split();
                    int rowIndexFirst = int.Parse(commands[1]);
                    int colIndexFirst = int.Parse(commands[2]);
                    int rowIndexSecond = int.Parse(commands[3]);
                    int colIndexSecond = int.Parse(commands[4]);

                    string firstElement = matrix[rowIndexFirst, colIndexFirst];
                    string secondElement = matrix[rowIndexSecond, colIndexSecond];

                    matrix[rowIndexSecond, colIndexSecond] = firstElement;
                    matrix[rowIndexFirst, colIndexFirst] = secondElement;

                    /*for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (row == rowIndexFirst && col == colIndexFirst)
                            {
                                matrix[row, col] = secondElement;
                            }
                            else if (row == rowIndexSecond && col == colIndexSecond)
                            {
                                matrix[row, col] = firstElement;
                            }
                        }
                    }*/
                    PrintMatrix(matrix);
                }
            }
        }

        private static bool validateCommand(string command, int rows, int cols)
        {
            string[] commands = command.Split();
            if (commands.Length == 5 && commands[0] == "swap"
                && int.Parse(commands[1]) <= rows
                && int.Parse(commands[2]) <= cols
                && int.Parse(commands[3]) <= rows
                && int.Parse(commands[4]) <= cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void FillMatrix(string[,] numbers)
        {
            for (int row = 0; row < numbers.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < numbers.GetLength(1); col++)
                {
                    numbers[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintMatrix(string[,] numbers)
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