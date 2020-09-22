using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];
            FillJaggedMatrix(matrix);

            for (int i = 0; i < rows - 1; i++)
            {
                if (matrix[i].Count() == matrix[i + 1].Count())
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }


            /* for (int row = 0; row < matrix.Length - 1; row++)
             {

                 int max = Math.Max(matrix[row].Length, (matrix[row + 1].Length));
                 int min = Math.Min(matrix[row].Length, (matrix[row + 1].Length));

                 for (int col = 0; col < max; col++)
                 {
                     if (matrix[row].Length == matrix[row + 1].Length)
                     {
                         matrix[row][col] *= 2;
                         matrix[row + 1][col] *= 2;
                     }
                     else
                     {
                         if (matrix[row].Length > matrix[row + 1].Length)
                         {
                             if (col < max)
                             {
                                 matrix[row][col] /= 2;
                             }
                             if (col < min)
                             {
                                 matrix[row + 1][col] /= 2;
                             }
                         }
                         else
                         {
                             if (col < max)
                             {
                                 matrix[row + 1][col] /= 2;
                             }
                             if (col < min)
                             {
                                 matrix[row][col] /= 2;
                             }
                         }

                     }
                 }
             }*/

            string input = Console.ReadLine();
            while (input != "End")
            {
                var elements = input.Split();

                int row = int.Parse(elements[1]);
                int col = int.Parse(elements[2]);
                double value = double.Parse(elements[3]);

                if (elements[0] == "Add")
                {
                    if (row >= 0 && row <= rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                }
                else
                {
                    if (row >= 0 && row <= rows && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }

                input = Console.ReadLine();
            }

            PrintJaggedMatrix(matrix);

        }

        private static void FillJaggedMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                double[] rowData = Console.ReadLine().Split().Select(double.Parse).ToArray();
                matrix[row] = new double[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];
                }
            }
        }

        private static void PrintJaggedMatrix(double[][] matrix)
        {
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