using System;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            TribonacciSequenceToN(n);

        }

        static void TribonacciSequenceToN(int n)
        {
            int first = 1;
            int second = 1;
            int third = 2;

            if (n >= 1)
            {
                Console.Write(first + " ");   
            }
            if (n >= 2)
            {
                Console.Write(second + " ");
            }
            if (n >= 3)
            {
                Console.Write(third);
            }
            
            for (int i = 1; i <= n - 3; i++)
            {
                int fourth = first + second + third;
                first = second;
                second = third;
                third = fourth;
                Console.Write(" " + fourth);
            }
        }
    }
}
