using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> items = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();
            items["motes"] = 0;
            items.Add("fragments", 0);
            items.Add("shards", 0);

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();

                bool hasToBreak = false;
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string name = input[i + 1].ToLower();
                    if (name == "shards" || name == "fragments" || name == "motes")
                    {
                        items[name] += quantity;

                        if (items[name] >= 250)
                        {
                            items[name] -= 250;
                            if (name == "shards")
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                            }
                            else if (name == "fragments")
                            {
                                Console.WriteLine($"Valanyr obtained!");
                            }
                            else
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
                            }
                            hasToBreak = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(name) == false)
                        {
                            junk[name] = 0;
                        }
                        junk[name] += quantity;

                    }
                }
                if (hasToBreak)
                {
                    break;
                }
            }
            Dictionary<string, int> filteredKeyMaterials = items
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, a => a.Value);
            foreach (var kvp in filteredKeyMaterials)
            {
                string material = kvp.Key;
                int quantity = kvp.Value;
                Console.WriteLine($"{material}: {quantity}");
            }
            foreach (var kvp in junk.OrderBy(kvp => kvp.Key))
            {
                string material = kvp.Key;
                int quantity = kvp.Value;
                Console.WriteLine($"{material}: {quantity}");
            }
        }
    }
}