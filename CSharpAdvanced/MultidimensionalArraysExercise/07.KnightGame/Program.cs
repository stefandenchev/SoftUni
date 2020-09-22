using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];
            FillMatrix(chessBoard);

            int countReplaced = 0;
            int rowKiller = 0;
            int colKiller = 0;

            while (true)
            {
                int maxAttacks = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        char currSym = chessBoard[row, col];
                        int countAttacks = 0;
                        if (currSym == 'K')
                        {
                            countAttacks = NewMethod(chessBoard, row, col, countAttacks);
                            if (countAttacks > maxAttacks)
                            {
                                maxAttacks = countAttacks;
                                rowKiller = row;
                                colKiller = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    chessBoard[rowKiller, colKiller] = '0';
                    countReplaced++;
                }
                else
                {
                    Console.WriteLine(countReplaced);
                    break;
                }
            }

        }

        private static int NewMethod(char[,] chessBoard, int row, int col, int countAttacks)
        {
            if (IsInside(chessBoard, row - 2, col + 1) && (chessBoard[row - 2, col + 1] == 'K'))
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row - 2, col - 1) && (chessBoard[row - 2, col - 1] == 'K'))
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 1, col + 2) && (chessBoard[row + 1, col + 2] == 'K'))
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 1, col - 2) && (chessBoard[row + 1, col - 2] == 'K'))
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row - 1, col + 2) && (chessBoard[row - 1, col + 2] == 'K'))
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row - 1, col - 2) && (chessBoard[row - 1, col - 2] == 'K'))
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 2, col - 1) && (chessBoard[row + 2, col - 1] == 'K'))
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 2, col + 1) && (chessBoard[row + 2, col + 1] == 'K'))
            {
                countAttacks++;
            }

            return countAttacks;
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

        private static bool IsInside(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessBoard.GetLength(0)
                && targetCol >= 0 && targetCol < chessBoard.GetLength(1);
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