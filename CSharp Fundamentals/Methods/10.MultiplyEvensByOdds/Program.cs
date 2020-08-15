using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);
            Console.WriteLine(MultiplyEvenAndOddDigits(n));
        }

/*        static int CalculateOddDigitSum(int n)
        {
            string number = n.ToString();
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == 1)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }*/

        static int CalculateDigitSum(int n, int isOdd)
        {
            string number = n.ToString();
            int sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                if (currentDigit % 2 == isOdd)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }

        static int MultiplyEvenAndOddDigits(int n)
        {
            return CalculateDigitSum(n, 0) * CalculateDigitSum(n, 1);
        }

    }
}

