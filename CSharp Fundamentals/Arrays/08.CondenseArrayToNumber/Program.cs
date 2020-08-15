using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            string[] input = Console.ReadLine().Split();
                        int[] nums = new int[input.Length];

                        for (int i = 0; i < input.Length; i++)
                        {
                            nums[i] = int.Parse(input[i]);
                        }*/

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (nums.Length != 1)
            {
                int[] newArr = new int[nums.Length - 1];
                for (int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = nums[i] + nums[i + 1];
                }
                // Console.WriteLine(String.Join(" ", newArr));
                nums = newArr;
            }
            Console.WriteLine(String.Join(" ", nums));

            /*int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int[] newArr = new int[nums.Length - 1];
                for (int j = 0; j < newArr.Length; j++)
                {
                    newArr[j] = nums[j] + nums[j + 1];
                }
            }*/
        }
    }
}
