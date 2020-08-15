using System;
using System.Linq;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            // ??

            Console.WriteLine(numbers);
        }
    }
}
