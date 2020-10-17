using System;
using System.Linq;
using System.Text;

namespace _02.BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder(word);

            char[,] field = new char[n, n];

            int wormRow = 0;
            int wormCol = 0;

            for (int row = 0; row < n; row++)
            {
                var currRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currRow[col];
                    if (field[row, col] == 'P')
                    {
                        wormRow = row;
                        wormCol = col;
                    }
                }
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                field[wormRow, wormCol] = '-';
                Move(ref input, ref wormRow, ref wormCol);

                if (wormRow < 0 || wormRow >= n || wormCol < 0 || wormCol >= n)
                {
                    Punish(ref input, ref wormRow, ref wormCol, ref sb);
                }

                if (Char.IsLetter(field[wormRow, wormCol]))
                {
                    sb.Append(field[wormRow, wormCol]);
                    field[wormRow, wormCol] = '-';
                }

                
                input = Console.ReadLine();
            }

            field[wormRow, wormCol] = 'P';
            Console.WriteLine(sb);
            PrintMatrix(field);

        }

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

        private static void Move(ref string direction, ref int wormRow, ref int wormCol)
        {
            if (direction == "up")
            {
                wormRow--;
            }

            else if (direction == "down")
            {
                wormRow++;
            }

            else if (direction == "left")
            {
                wormCol--;
            }

            else if (direction == "right")
            {
                wormCol++;
            }
        }
        public static void Punish(ref string direction, ref int wormRow, ref int wormCol, ref StringBuilder sb)
        {
            if (direction == "up")
            {
                wormRow++;
            }

            else if (direction == "down")
            {
                wormRow--;
            }

            else if (direction == "left")
            {
                wormCol++;
            }

            else if (direction == "right")
            {
                wormCol--;
            }

            if (sb.Length > 0)
            {
                sb.Length--;
            }

        }
    }
}
