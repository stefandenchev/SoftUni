﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<int>> towns = new Dictionary<string, List<int>>();

            while (input != "Sail")
            {
                var elements = input.Split("||");
                string name = elements[0];
                int people = int.Parse(elements[1]);
                int gold = int.Parse(elements[2]);
                if (towns.ContainsKey(name))
                {
                    towns[name][0] += people;
                    towns[name][1] += gold;
                }
                else
                {
                    towns.Add(name, new List<int>() { people, gold });
                }

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                if (input.Contains("Plunder"))
                {
                    var elements = input.Split("=>");
                    string town = elements[1];
                    int people = int.Parse(elements[2]);
                    int gold = int.Parse(elements[3]);

                    towns[town][0] -= people;
                    towns[town][1] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (towns[town][0] <= 0 || towns[town][1] <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        towns.Remove(town);
                    }
                }

                if (input.Contains("Prosper"))
                {
                    var elements = input.Split("=>");
                    string town = elements[1];
                    int gold = int.Parse(elements[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        towns[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {towns[town][1]} gold.");
                    }

                }
                input = Console.ReadLine();
            }

            towns = towns.OrderByDescending(t => t.Value[1])
                .ThenBy(t => t.Key).ToDictionary(t => t.Key, t => t.Value);

            if (towns.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

                foreach (var town in towns)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }

        }
    }
}