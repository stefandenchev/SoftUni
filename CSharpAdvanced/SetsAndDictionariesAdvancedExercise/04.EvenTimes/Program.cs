using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(num))
                {
                    nums.Add(num, 1);
                }
                else
                {
                    nums[num]++;
                }
            }

            int even = 0;

            foreach (var num in nums)
            {
                if (num.Value % 2 == 0)
                {
                    even = num.Key;
                }
            }
            Console.WriteLine(even);
        }
    }
}