using System;

namespace _02.TronRacersDirty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int firstRow = 0;
            int firstCol = 0;
            int secondRow = 0;
            int secondCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                }
            }

            while (true)
            {
                var elements = Console.ReadLine().Split();
                string firstMovement = elements[0];
                string secondMovement = elements[1];
              
                Move(ref firstMovement, ref firstRow, ref firstCol);
                CheckBoundaries(ref firstRow, ref firstCol, ref n);

                if (matrix[firstRow, firstCol] == 's')
                {
                    matrix[firstRow, firstCol] = 'x';
                    break;
                }
                else
                {
                    matrix[firstRow, firstCol] = 'f';
                }

                Move(ref secondMovement, ref secondRow, ref secondCol);
                CheckBoundaries(ref secondRow, ref secondCol, ref n);

                if (matrix[secondRow, secondCol] == 'f')
                {
                    matrix[secondRow, secondCol] = 'x';
                    break;
                }
                else
                {
                    matrix[secondRow, secondCol] = 's';
                }

            }

            Print(matrix);
        }



        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(ref string direction, ref int row, ref int col)
        {
            if (direction == "up")
            {
                row--;
            }

            else if (direction == "down")
            {
                row++;
            }

            else if (direction == "left")
            {
                col--;
            }

            else if (direction == "right")
            {
                col++;
            }
        }

      private static void CheckBoundaries(ref int row, ref int col, ref int n)
        {
            if (row < 0)
            {
                row = n - 1;
            }

            else if (row > n - 1)
            {
                row = 0;
            }

            else if (col < 0)
            {
                col = n - 1;
            }

            else if (col > n - 1)
            {
                col = 0;
            }
        }

    }
}