using System;

namespace _01.SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int high = Math.Max(Math.Max(a, b), c);
            int low = Math.Min(Math.Min(a, b), c);
            int mid = a + b + c - high - low;

            Console.WriteLine(high);
            Console.WriteLine(mid);
            Console.WriteLine(low);
        }
    }
}
