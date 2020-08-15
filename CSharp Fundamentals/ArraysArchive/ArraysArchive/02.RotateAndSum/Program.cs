using System;
using System.Linq;

namespace _02.RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] sum = new int[numbers.Length];

            for (int i = 0; i < rotations; i++)
            {
                int lastNumber = numbers[numbers.Length - 1];
                int[] tempNumbers = new int[numbers.Length];
                tempNumbers[0] = lastNumber;
                for (int j = 1; j < tempNumbers.Length; j++)
                {
                    tempNumbers[j] = numbers[j - 1];
                }
                for (int j = 0; j < sum.Length; j++)
                {
                    sum[j] += tempNumbers[j];
                }
                numbers = tempNumbers;
            }
            Console.WriteLine(String.Join(" ", sum));
        }
    }
}
