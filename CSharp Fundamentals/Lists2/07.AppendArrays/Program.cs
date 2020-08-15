using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> startingList = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            for (int i = 0; i < startingList.Count; i++)
            {
                List<string> numbers = startingList[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int j = 0; j < numbers.Count; j++)
                {
                    Console.Write($"{numbers[j]}" + " ");
                }
            }
        }
    }
}
