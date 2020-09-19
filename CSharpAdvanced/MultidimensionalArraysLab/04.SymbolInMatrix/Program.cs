using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            char searched = char.Parse(Console.ReadLine());
            int searchedRow = 0;
            int searchedCol = 0;
            bool isFound = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == searched)
                    {
                        searchedRow = row;
                        searchedCol = col;
                        isFound = true;
                        Console.WriteLine($"({searchedRow}, {searchedCol})");
                        return;
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{searched} does not occur in the matrix");
            }
        }
    }
}