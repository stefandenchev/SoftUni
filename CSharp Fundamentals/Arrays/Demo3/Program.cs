using System;

namespace Demo3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4 };
            int sum = 0;

           for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 1) // i % 2 == 0
                {
                    sum += numbers[i];
                }
            }
            Console.WriteLine(sum);

/*            foreach (var num in numbers)
            {
                sum += num;
            }
            Console.WriteLine(sum);*/
        }
    }
}
