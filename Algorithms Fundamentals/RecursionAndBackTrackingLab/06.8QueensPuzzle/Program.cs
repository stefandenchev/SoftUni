using System;
using System.Collections.Generic;

namespace _06._8QueensPuzzle
{
    class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiags = new HashSet<int>();
        private static HashSet<int> attackedRightDiags = new HashSet<int>();
        static void Main(string[] args)
        {
            var board = new bool[8, 8];

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (!IsAttacked(row, col))
                {
                    board[row, col] = true;
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiags.Add(row - col);
                    attackedRightDiags.Add(row + col);

                    PutQueens(board, row + 1);

                    board[row, col] = false;
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiags.Remove(row - col);
                    attackedRightDiags.Remove(row + col);
                }
            }
        }

        private static bool IsAttacked(int row, int col)
        {
            return attackedRows.Contains(row)
                || attackedCols.Contains(col)
                || attackedLeftDiags.Contains(row - col)
                || attackedRightDiags.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write($"* ");
                    }
                    else
                    {
                        Console.Write($"- ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
