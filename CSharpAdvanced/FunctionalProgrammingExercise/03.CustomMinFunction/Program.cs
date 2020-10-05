using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minFunc = nums =>
            {
                int minNum = int.MaxValue;
                foreach (int num in nums)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };
            Console.WriteLine(minFunc(numbers)); 
        }
    }
}