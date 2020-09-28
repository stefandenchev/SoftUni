using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                foreach (var element in line)
                {
                    elements.Add(element);
                }
            }
            var sorted = elements.OrderBy(x => x);
            Console.WriteLine(String.Join(" ", sorted));
        }
    }
}