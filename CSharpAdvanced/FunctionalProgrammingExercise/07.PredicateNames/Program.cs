using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, bool> predicate = x => x.Length <= n;
            names = names.Where(predicate).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
