using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()?
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stones);

            /*List<int> path = new List<int>();
            foreach (int stone in lake)
            {
                path.Add(stone);
            }*/

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
