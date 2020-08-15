using System;

namespace _07.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int copy = n;      
            int sum = 0;

            while (n > 0)
            {
                int factorial = 1;
                int number = n % 10;
                n /= 10;

                for (int i = 2; i <= number; i++)
                {
                    factorial *= i;
                }

                sum += factorial;
            }
            if (sum == copy)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
