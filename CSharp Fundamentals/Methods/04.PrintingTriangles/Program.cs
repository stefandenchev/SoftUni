using System;

namespace _04.PrintingTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTriangles(n);
        }
        static void PrintTriangles(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                PrintNumbersBetween(1, i);
            }
            for (int i = n- 1; i >= 1; i--)
            {
                PrintNumbersBetween(1, i);
            }
        }
        static void PrintNumbersBetween(int from, int to)
        {
            for (int i = 1; i <= to; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
