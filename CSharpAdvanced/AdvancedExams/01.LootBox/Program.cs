using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>();
            var firstLootBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondLootBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstLootBox);
            Stack<int> secondBox = new Stack<int>(secondLootBox);

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                var firstLoot = firstBox.Peek();
                var secondLoot = secondBox.Peek();
                var sum = firstLoot + secondLoot;

                if (sum % 2 == 0)
                {
                    collection.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    secondBox.Pop();
                    firstBox.Enqueue(secondLoot);
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int lootSum = collection.Sum();
            if (lootSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {lootSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {lootSum}");
            }
        }
    }
}