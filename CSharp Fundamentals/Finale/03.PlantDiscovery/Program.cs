using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class PlantStats
    {
        public int Rarity { get; set; }
        public int Rating { get; set; }
        public double TimesRated { get; set; }
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
                    var rating = int.Parse(elements[2]);
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].Rating += rating;
                        plants[plant].TimesRated++;
                    }
                    else
                    {
                        Console.WriteLine("error");
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
                        plants[plant].Rating = 0;
                        plants[plant].TimesRated = 0;
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

            foreach (var plant in plants)
            {
                if (double.Equals(double.NaN, plant.Value.Rating))
                    plant.Value.Rating = 0;
            }

            var sortedPlants = plants.OrderByDescending(x => x.Value.Rarity).ThenByDescending(x => x.Value.Rating);

            Console.WriteLine("Plants for the exhibition:");


            foreach (var plant in sortedPlants)
            {
                Console.Write($" - {plant.Key}; Rarity: {plant.Value.Rarity}; ");
                double finalRating = 0;
                if (plant.Value.TimesRated != 0)
                {
                    finalRating = 1.0 * plant.Value.Rating / plant.Value.TimesRated;
                }
                Console.WriteLine($"Rating: {finalRating:f2}");
            }
        }
    }
}