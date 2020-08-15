using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstFactorial = double.Parse(Console.ReadLine());
            double secondFactorial = double.Parse(Console.ReadLine());
            double firstResult = CalculateFactorial(firstFactorial);
            double secondResult = CalculateFactorial(secondFactorial);
            DivideFactorialResults(firstResult, secondResult);
        }
        static double CalculateFactorial(double factorial)
        {
            double result = 1;
            for (double i = 1; i <= factorial; i++)
            {
                result *= i;
            }
            return result;
        }
        static void DivideFactorialResults(double firstResult, double secondResult)
        {
            double finalResult = firstResult / secondResult;
            Console.WriteLine($"{finalResult:f2}");
        }
    }
}
