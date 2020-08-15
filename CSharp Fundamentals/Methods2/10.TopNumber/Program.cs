using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintTopNumber(number);
        }
        static void PrintTopNumber(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                bool isOdd = false;
                int sum = 0;
                int currentNumber = i;

                while (currentNumber != 0)
                {
                    if (currentNumber % 2 == 1)
                    {
                        isOdd = true;
                    }
                    sum += currentNumber % 10;
                    currentNumber /= 10;
                }

                if (sum % 8 == 0 && isOdd)
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}
