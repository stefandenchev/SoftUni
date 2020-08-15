using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            Calculator(first, second, Console.ReadLine());

            static void Calculator(double first, double second, string sign)
            {
                double result = 0;
                if(sign == "+")
                {
                    result = first + second;
                }
                if(sign == "-")
                {
                    result = first - second;
                }
                if(sign == "*")
                {
                    result = first * second;
                }
                if(sign == "/")
                {
                    result = first / second;
                }
                Console.WriteLine(result);
            }
        }
    }
}
