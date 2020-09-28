using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var color = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[0];
                var clothes = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color][clothes[j]]++;
                    }
                    else
                    {
                        wardrobe[color].Add(clothes[j], 1);
                    }
                }

            }

            var searched = Console.ReadLine().Split();

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var piece in color.Value)
                {
                    if (searched[0] == color.Key && searched[1] == piece.Key)
                    {
                        Console.WriteLine($"* {piece.Key} - {piece.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {piece.Key} - {piece.Value}");
                    }
                }

            }
        }
    }
}