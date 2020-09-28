using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> chars = new Dictionary<char, int>();

            var elements = Console.ReadLine().ToCharArray();

            for (int i = 0; i < elements.Count(); i++)
            {
                var currChar = elements[i];

                if (!chars.ContainsKey(currChar))
                {
                    chars.Add(currChar, 1);
                }
                else
                {
                    chars[currChar]++;
                }
            }

            var sorted = chars.OrderBy(x => x.Key);

            foreach (var ch in sorted)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }

        }
    }
}