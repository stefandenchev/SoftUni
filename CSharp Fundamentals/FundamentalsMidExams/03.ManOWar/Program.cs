using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Retire")
            {
                var elements = input.Split();
                var command = elements[0];

                switch (command)
                {
                    case "Fire":
                        int indexToFire = int.Parse(elements[1]);
                        if (indexToFire >= 0 && indexToFire <= warShip.Count - 1)
                        {
                            int damage = int.Parse(elements[2]);
                            int currentSegmentHealth = warShip.ElementAt(indexToFire);
                            currentSegmentHealth -= damage;
                            if (currentSegmentHealth <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                            else
                            {
                                warShip.RemoveAt(indexToFire);
                                warShip.Insert(indexToFire, currentSegmentHealth);
                            }
                        }
                        break;

                    case "Defend":
                        int startIndex = int.Parse(elements[1]);
                        int endIndex = int.Parse(elements[2]);
                        if ((startIndex >= 0 && startIndex <= pirateShip.Count - 1) && (endIndex >= 0 && endIndex <= pirateShip.Count - 1))
                        {
                            int damage = int.Parse(elements[3]);

                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                int currentSegmentHealth = pirateShip.ElementAt(i);
                                currentSegmentHealth -= damage;
                                if (currentSegmentHealth <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                                else
                                {
                                    pirateShip.RemoveAt(i);
                                    pirateShip.Insert(i, currentSegmentHealth);
                                }
                            }
                        }
                        break;

                    case "Repair":
                        int indexToRepair = int.Parse(elements[1]);
                        if (indexToRepair >= 0 && indexToRepair <= pirateShip.Count - 1)
                        {
                            int health = int.Parse(elements[2]);
                            int segmentHealth = pirateShip.ElementAt(indexToRepair);
                            segmentHealth += health;
                            if (segmentHealth > maxHealth)
                            {
                                segmentHealth = maxHealth;
                            }
                            pirateShip.RemoveAt(indexToRepair);
                            pirateShip.Insert(indexToRepair, segmentHealth);
                        }
                        break;

                    case "Status":
                        int count = 0;
                        foreach (var segment in pirateShip.Where(x => x < 0.2 * maxHealth))
                        {
                            count++;
                        }
                        Console.WriteLine($"{count} sections need repair.");
                        break;
                }

                input = Console.ReadLine();
            }

            int pirateShipSum = pirateShip.Sum();
            int warShipSum = warShip.Sum();

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");

        }
    }
}