using System;

namespace _01.MetersToKM
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            Console.WriteLine($"{meters * 0.001:f2}");
        }
    }
}
