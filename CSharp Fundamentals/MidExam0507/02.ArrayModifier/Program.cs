using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                var elements = input.Split();
                string command = elements[0];

                switch (command)
                {
                    case "swap":
                        int index1 = int.Parse(elements[1]);
                        int index2 = int.Parse(elements[2]);
                        int num1 = nums[index1];
                        int num2 = nums[index2];

                        nums.Insert(index1, num2);
                        nums.RemoveAt(index1 + 1);
                        nums.Insert(index2, num1);
                        nums.RemoveAt(index2 + 1);

                        break;

                    case "multiply":
                        int index1M = int.Parse(elements[1]);
                        int index2M = int.Parse(elements[2]);
                        int num1M = nums[index1M];
                        int num2M = nums[index2M];

                        int result = num1M * num2M;
                        nums.Insert(index1M, result);
                        nums.RemoveAt(index1M + 1);

                        break;

                    case "decrease":
                        for (int i = 0; i < nums.Count; i++)
                        {
                            nums[i]--;
                        }
                        break;


                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", nums));
        }
    }
}
