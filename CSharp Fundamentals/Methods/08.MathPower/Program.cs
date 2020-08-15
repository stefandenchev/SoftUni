using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(CalculatePower(n, power));

            static double CalculatePower(double number, double power)
            {
                double result = 1;
                for (int i = 0; i < power; i++)
                {
                    result *= number;
                }
                return result;
            }
        }
    }
}
