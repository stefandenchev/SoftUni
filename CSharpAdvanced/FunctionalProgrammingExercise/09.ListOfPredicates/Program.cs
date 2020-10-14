using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> numbers = new List<int>();
            for (int i = 1; i <= length; i++)
            {
                if (Divider(i, dividers))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool Divider(int n, List<int> dividers)
        {
            bool flag = true;
            foreach (int divaider in dividers)
            {
                if (n % divaider != 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}