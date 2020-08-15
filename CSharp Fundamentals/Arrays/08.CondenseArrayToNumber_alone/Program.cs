using System;
using System.Linq;

namespace _08.CondenseArrayToNumber_alone
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (nums.Length != 1)
            {
                int[] temp = new int[nums.Length - 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = nums[i] + nums[i + 1];
                }
                nums = temp;
            }
            Console.WriteLine(String.Join("", nums));
        }
    }
}