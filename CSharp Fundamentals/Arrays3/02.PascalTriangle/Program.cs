using System;

namespace _02.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int coef = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                    {
                        coef = 1;
                        Console.Write(coef + " ");
                    }
                    else
                    {
                        coef = coef * (i - j + 1) / j;
                        Console.Write(coef + " ");
                    }
                }
                    Console.WriteLine();
            }
        }
    }
}
