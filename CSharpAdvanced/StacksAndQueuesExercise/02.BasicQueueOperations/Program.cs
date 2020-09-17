using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int s = input[1];
            int x = input[2];
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(nums);

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            /*var newNums = queue.ToList();
            newNums.Sort();*/

            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
                //Console.WriteLine(newNums[0]);
            }
        }
    }
}