using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class PlantStats
    {
        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, PlantStats> plants = new Dictionary<string, PlantStats>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var elements = input.Split("<->");
                var plant = elements[0];
                var rarity = int.Parse(elements[1]);

                if (!plants.ContainsKey(plant))
                {
                    PlantStats plantStats = new PlantStats { Rarity = rarity };
                    plants.Add(plant, plantStats);
                }
                else
                {
                    plants[plant].Rarity = rarity;
                }
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                var elements = command.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("Rate"))
                {
                    var plant = elements[1];
                    var rating = double.Parse(elements[2]);
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rating
                    }
                    else
                    {
                        plants[plant].Rating.Add(rating);
                    }
                }

                else if (command.Contains("Update"))
                {
                    var plant = elements[1];
                    var rarity = int.Parse(elements[2]);
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rarity = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else if (command.Contains("Reset"))
                {
                    var plant = elements[1];
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rating.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                else
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;
                }

                command = Console.ReadLine();
            }

            var sortedPlants = plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating.Average());

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in sortedPlants)
            {
                Console.WriteLine($" - {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {(plant.Value.Rating.Average()):f2}");
            }
        }
    }
}