﻿using System;
using System.Collections.Generic;

namespace _05.PathsInLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var labyrinth = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < line.Length; c++)
                {
                    labyrinth[r, c] = line[c];
                }
            }

            var directions = new List<char>();

            FindAllPaths(labyrinth, 0, 0, directions, '\0');
        }

        private static void FindAllPaths(char[,] labyrinth, int row, int col,
            List<char> directions, char direction)
        {
            if (IsOutside(labyrinth, row, col)
                || IsWall(labyrinth, row, col)
                || IsVisited(labyrinth, row, col))
            {
                return;
            }

            directions.Add(direction);

            if (IsSolution(labyrinth, row, col))
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }
            
            labyrinth[row, col] = 'v';

            FindAllPaths(labyrinth, row - 1, col, directions, 'U');
            FindAllPaths(labyrinth, row + 1, col, directions, 'D');
            FindAllPaths(labyrinth, row, col - 1, directions, 'L');
            FindAllPaths(labyrinth, row, col + 1, directions, 'R');

            directions.RemoveAt(directions.Count - 1);
            labyrinth[row, col] = '-';
        }

        private static bool IsSolution(char[,] labyrinth, int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        private static bool IsVisited(char[,] labyrinth, int row, int col)
        {
            return labyrinth[row, col] == 'v';
        }

        private static bool IsWall(char[,] labyrinth, int row, int col)
        {
            return labyrinth[row, col] == '*';
        }

        private static bool IsOutside(char[,] labyrinth, int row, int col)
        {
            return row < 0
                || row >= labyrinth.GetLength(0)
                || col < 0
                || col >= labyrinth.GetLength(1);
        }
    }
}