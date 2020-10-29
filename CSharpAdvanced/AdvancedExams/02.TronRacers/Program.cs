using System;

namespace _02.TronRacers
{
    class Program
    {
        public class Position
        {
            public Position(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public bool IsSafe(int rowCount, int colCount)
            {
                if (Row < 0 || Col < 0)
                {
                    return false;
                }
                if (Row >= rowCount || Col >= colCount)
                {
                    return false;
                }

                return true;
            }

            public void CheckOtherSideMovement(int rowCount, int colCount)
            {
                if (Row < 0)
                {
                    Row = rowCount - 1;
                }
                if (Col < 0)
                {
                    Col = colCount - 1;
                }
                if (Row >= rowCount)
                {
                    Row = 0;
                }
                if (Col >= colCount)
                {
                    Col = 0;
                }
            }

            public static Position GetDirection(string command)
            {
                int row = 0;
                int col = 0;
                if (command == "left")
                {
                    col = -1;
                }
                if (command == "right")
                {
                    col = 1;
                }
                if (command == "up")
                {
                    row = -1;
                }
                if (command == "down")
                {
                    row = 1;
                }

                return new Position(row, col);
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            Read(matrix);

            var firstPlayer = GetFirstPlayerPosition(matrix);
            var secondPlayer = GetSecondPlayerPosition(matrix);

            while (true)
            {
                var elements = Console.ReadLine().Split();
                var firstMovement = elements[0];
                var secondMovement = elements[1];

                MovePlayer(firstPlayer, firstMovement, n);

                if (matrix[firstPlayer.Row, firstPlayer.Col] == 's')
                {
                    matrix[firstPlayer.Row, firstPlayer.Col] = 'x';
                    break;
                }
                else
                {
                    matrix[firstPlayer.Row, firstPlayer.Col] = 'f';
                }

                MovePlayer(secondPlayer, secondMovement, n);
                if (matrix[secondPlayer.Row, secondPlayer.Col] == 'f')
                {
                    matrix[secondPlayer.Row, secondPlayer.Col] = 'x';
                    break;
                }
                else
                {
                    matrix[secondPlayer.Row, secondPlayer.Col] = 's';
                }

            }

            Print(matrix);
        }

        static Position MovePlayer(Position player, string command, int n)
        {
            Position movement = Position.GetDirection(command);
            player.Row += movement.Row;
            player.Col += movement.Col;
            player.CheckOtherSideMovement(n, n);

            return player;
        }

        static Position GetFirstPlayerPosition(char[,] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
        }

        static Position GetSecondPlayerPosition(char[,] matrix)
        {
            Position position = null;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        position = new Position(row, col);
                    }
                }
            }

            return position;
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

        private static void Read(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

    }
}