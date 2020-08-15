using System;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int[] numbers = new int[] { num1, num2, num3 };

            FindIfProductIsPositiveOrNegative(numbers);
        }

        static void FindIfProductIsPositiveOrNegative(int[] numbers)
        {
            bool isZero = false;
            int negCount = 0;
            int posCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int checker = numbers[i];
                if (checker < 0)
                {
                    negCount++;
                }
                else if (checker > 0)
                {
                    posCount++;
                }
                else
                {
                    isZero = true;
                }
            }

            if (isZero)
            {
                Console.WriteLine("zero");
                return;
            }
            if (negCount == 1 || negCount == 3)
            {
                Console.WriteLine("negative");
                return;
            }
            else
            {
                Console.WriteLine("positive");
            }
        }

    }
}
