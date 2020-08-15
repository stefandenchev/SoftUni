﻿using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int minNum = MinNum(num1, num2, num3);
            Console.WriteLine(minNum);
        }

        static int MinNum(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
    }
}
