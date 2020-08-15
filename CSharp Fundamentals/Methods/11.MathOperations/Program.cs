using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char sign = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            MathOperations(a, sign, b);
        }

        static void MathOperations(int a, char sign, int b)
        {
            int result = 0;
            switch (sign)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;
            }
            Console.WriteLine(result);
        }

    }
}
