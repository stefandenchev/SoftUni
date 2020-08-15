using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> topFive = new List<double>();

            double average = nums.Average();

            int counter = 0;

            foreach (var num in nums.Where(x => x > average))
            {
                topFive.Add(num);
                counter++;
            }
            topFive.Sort();
            topFive.Reverse();

            if (counter == 0)
            {
                Console.WriteLine("No");
            }
            else if (counter <= 5)
            {
                Console.WriteLine(String.Join(" ", topFive));
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(topFive[i] + " ");
                }
            }
        }
    }
}