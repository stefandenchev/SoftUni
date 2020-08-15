using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .Take(3)
                .ToList();

            Console.WriteLine(String.Join(" ", numbers));

        }
    }
}
