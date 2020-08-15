using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> rule = new List<int>();
            List<int> maxList = new List<int>();
            List<int> mixedList = new List<int>();

            if (numbers1.Count > numbers2.Count)
            {
                maxList = numbers1;
            }
            else
            {
                maxList = numbers2;
                maxList.Reverse();
            }

            for (int i = maxList.Count - 2; i < maxList.Count; i++)
            {
                rule.Add(maxList[i]);
            }
            rule.Sort();

            if (numbers1.Count > numbers2.Count)
            {
                numbers1.RemoveRange(numbers1.Count - 2, 2);
                numbers2.Reverse();
            }
            else
            {
                numbers2.RemoveRange(numbers2.Count - 2, 2);
                numbers2.Reverse();
            }

            for (int i = 0; i < numbers1.Count; i++)
            {
                mixedList.Add(numbers1[i]);
                mixedList.Add(numbers2[i]);
            }
            List<int> output = mixedList.FindAll(x => x > rule[0] && x < rule[1]);
            output.Sort();
            Console.WriteLine(String.Join(" ", output));
        }
    }
}
