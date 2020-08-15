using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int b = 1;
            int c;

            if (n == 0)
            {
                Console.WriteLine(n);

                for (int i = 2; i <= n; i++)
                {
                    c = a + b;
                    a = b;
                    c = b;
                Console.WriteLine(n);
                }
            }
        }
    }
}
