using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rowSize][];
            for (int r = 0; r < rowSize; r++)
            {
                int[] columns = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[r] = new int[columns.Length];
                for (int c = 0; c < columns.Length; c++)
                {
                    matrix[r] = columns;
                }
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                var elements = input.Split();
                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);
                int value = int.Parse(elements[3]);

                bool isInvalid = false;
                if (matrix.Length <= row || row < 0)
                {
                    isInvalid = true;
                }
                else if (matrix.Length <= col || col < 0)
                {
                    isInvalid = true;
                }
                if (isInvalid)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (elements[0].Contains("Add"))
                    {
                        matrix[row][col] += value;
                    }
                    if (elements[0].Contains("Subtract"))
                    {
                        matrix[row][col] -= value;
                    }
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}