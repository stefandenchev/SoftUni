using System;

namespace _02.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int santaRow = 0;
            int santaCol = 0;

            int goodKidsTotal = 0;
            int goodKidsWithGifts = 0;

            for (int row = 0; row < n; row++)
            {
                var currRow = Console.ReadLine();
                currRow = currRow.Replace(" ", "");
                var currRowArray = currRow.ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = currRowArray[col];
                    if (field[row, col] == ' ')
                    {
                        col--;
                    }
                    if (field[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    if (field[row, col] == 'V')
                    {
                        goodKidsTotal++;
                    }
                }
            }

            bool noPresents = false;
            string input = Console.ReadLine();

            while (input != "Christmas morning")
            {
                field[santaRow, santaCol] = '-';

                Move(ref input, ref santaRow, ref santaCol);

                if (field[santaRow, santaCol] == 'X')
                {
                    field[santaRow, santaCol] = '-';
                }

                if (field[santaRow, santaCol] == 'V')
                {
                    field[santaRow, santaCol] = '-';
                    presentsCount--;
                    goodKidsWithGifts++;
                }

                if (field[santaRow, santaCol] == 'C')
                {
                    if (field[santaRow - 1, santaCol] == 'V')
                    {
                        field[santaRow - 1, santaCol] = '-';
                        goodKidsWithGifts++;
                        presentsCount--;
                    }
                    else if (field[santaRow - 1, santaCol] == 'X')
                    {
                        field[santaRow - 1, santaCol] = '-';
                        presentsCount--;
                    }

                    if (field[santaRow + 1, santaCol] == 'V')
                    {
                        field[santaRow + 1, santaCol] = '-';
                        goodKidsWithGifts++;
                        presentsCount--;
                    }
                    else if (field[santaRow + 1, santaCol] == 'X')
                    {
                        field[santaRow + 1, santaCol] = '-';
                        presentsCount--;
                    }

                    if (field[santaRow, santaCol - 1] == 'V')
                    {
                        field[santaRow, santaCol - 1] = '-';
                        goodKidsWithGifts++;
                        presentsCount--;
                    }
                    else if (field[santaRow, santaCol - 1] == 'X')
                    {
                        field[santaRow, santaCol - 1] = '-';
                        presentsCount--;
                    }

                    if (field[santaRow, santaCol + 1] == 'V')
                    {
                        field[santaRow, santaCol + 1] = '-';
                        goodKidsWithGifts++;
                        presentsCount--;
                    }
                    else if (field[santaRow, santaCol + 1] == 'X')
                    {
                        field[santaRow, santaCol + 1] = '-';
                        presentsCount--;
                    }
                }

                if (presentsCount == 0)
                {
                    noPresents = true;
                    break;
                }

                input = Console.ReadLine();
            }

            field[santaRow, santaCol] = 'S';

            if (noPresents)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            PrintMatrix(field);

            if (goodKidsTotal == goodKidsWithGifts)
            {
                Console.WriteLine($"Good job, Santa! {goodKidsTotal} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {goodKidsTotal - goodKidsWithGifts} nice kid/s.");
            }
        }

        private static void Move(ref string direction, ref int santaRow, ref int santaCol)
        {
            if (direction == "up")
            {
                santaRow--;
            }

            else if (direction == "down")
            {
                santaRow++;
            }

            else if (direction == "left")
            {
                santaCol--;
            }

            else if (direction == "right")
            {
                santaCol++;
            }
        }
        private static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]}" + " ");
                }
                Console.WriteLine();
            }
        }
    }
}