using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            names = names.Select(n => $"Sir {n}").ToList();

            Action<string[]> printNames = x => Console.WriteLine(String.Join(Environment.NewLine, x));

            printNames(names.ToArray());
        }
    }
}