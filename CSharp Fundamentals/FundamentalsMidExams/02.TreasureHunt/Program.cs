using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|").ToList();

            string input = Console.ReadLine();

            while (input != "Yohoho!")
            {
                var elements = input.Split();

                string command = elements[0];

                switch (command)
                {
                    case "Loot":
                        for (int i = 1; i <= elements.Length - 1; i++)
                        {
                            StringBuilder sb = new StringBuilder();

                            foreach (char chr in elements[i])
                            {
                                sb.Append(chr.ToString());
                            }

                            string currentItem = sb.ToString();

                            if (!chest.Contains(currentItem))
                            {
                                chest.Insert(0, currentItem);
                            }
                        }
                        break;

                    case "Drop":
                        int index = int.Parse(elements[1]);
                        if (index >= 0 && index <= chest.Count)
                        {
                            string item = chest.ElementAt(index);
                            chest.RemoveAt(index);
                            chest.Add(item);
                        }
                        break;

                    case "Steal":
                        List<string> stolenItems = new List<string>();
                        int number = int.Parse(elements[1]);
                        if (number >= chest.Count)
                        {
                            foreach (var item in chest)
                            {
                                stolenItems.Add(item);
                            }
                            chest.Clear();
                            Console.WriteLine(String.Join(", ", stolenItems));
                        }
                        else
                        {
                            for (int i = chest.Count - 1; i >= chest.Count - number; i--)
                            {
                                stolenItems.Add(chest[i]);
                            }
                            int initialChestCount = chest.Count;
                            for (int i = chest.Count - 1; i >= initialChestCount - number; i--)
                            {
                                chest.RemoveAt(i);
                            }
                            stolenItems.Reverse();
                            Console.WriteLine(String.Join(", ", stolenItems));
                        }

                        break;
                }
                input = Console.ReadLine();
            }

            int itemsLength = 0;

            for (int i = 0; i < chest.Count; i++)
            {
                char[] characters = chest[i].ToCharArray();

                foreach (char item in characters)
                {
                    itemsLength++;
                }
            }

            double averageGain = 1.0 * itemsLength / chest.Count;

            if (chest.Count > 0)
            {
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }

        }
    }
}