using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            List<string> evenLength = words.Where(word => word.Length % 2 == 0).ToList();
            Console.WriteLine(String.Join("\n", evenLength));
        }
    }
}