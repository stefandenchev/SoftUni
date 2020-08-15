using System;

namespace _06.CalculateRectangeArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateRecrangeArea(int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine())));
        }
        static int CalculateRecrangeArea(int a, int b)
        {
            return a * b;
        }
    }
}
