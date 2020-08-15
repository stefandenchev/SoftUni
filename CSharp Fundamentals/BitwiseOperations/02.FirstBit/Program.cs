using System;

namespace _02.FirstBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine((num >> 1) & 1);
        }
    }
}
