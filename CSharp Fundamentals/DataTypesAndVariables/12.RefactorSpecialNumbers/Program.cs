using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool isSpecialNumber = false;
            int total = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                while (currentNumber > 0)
                {
                    total += currentNumber % 10;
                    currentNumber = currentNumber / 10;
                }
                isSpecialNumber = (total == 5) || (total == 7) || (total == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecialNumber);
                total = 0;
                // i = currentNumber;
            }
        }
    }
}
