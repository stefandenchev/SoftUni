using System;
using System.Collections.Generic;

namespace _07.RecursiveFibonacci
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(SolveMemoization(n));
        }

        public static double SolveMemoization(int n)
        {
            double result;
            if (memo.ContainsKey(n))
            {
                result = memo[n];
            }
            else
            {
                result = SolveMemoization(n - 1) + SolveMemoization(n - 2);
                memo[n] = result;
            }
            return result;

        }

        static Dictionary<int, double> memo = new Dictionary<int, double>() {
            {0, 1},
            {1, 1}
        };
    }
}