using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (operation == "add")
            {
                Add(a, b);
            }
            else if (operation == "subtract")
            {
                Subtract(a, b);
            }
            else if (operation == "multiply")
            {
                Multiply(a, b);
            }
            else if (operation == "divide")
            {
                Divide(a, b);
            }

        }
        static void Add(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine(sum);
        }
        static void Subtract(int a, int b)
        {
            int difference = a - b;
            Console.WriteLine(difference);
        }
        static void Multiply(int a, int b)
        {
            int product = a * b;
            Console.WriteLine(product);
        }
        static void Divide(int a, int b)
        {
            int quotient = a / b;
            Console.WriteLine(quotient);
        }
    }
}
