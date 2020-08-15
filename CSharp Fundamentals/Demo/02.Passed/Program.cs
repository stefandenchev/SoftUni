using System;

namespace _02.Passed // 03.orFailed
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = Double.Parse(Console.ReadLine());
            bool isPassed = grade >= 3.00;

            if (isPassed)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
