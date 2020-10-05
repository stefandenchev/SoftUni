using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine().Split(", ").Select(decimal.Parse).Select(x => x * 1.2m).ToArray();
            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}