using System;

namespace _05.AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int result = Sum(a, b);
            Substract(result, c);
        }
        static int Sum(int a, int b)
        {
            int sum = a + b;
            return sum;
        }
        static void Substract(int result, int c)
        {
            result -= c;
            Console.WriteLine(result);
        }
    }
}
