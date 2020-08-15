using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 123;
            int sum = 0;

            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
