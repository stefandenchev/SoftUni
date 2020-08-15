using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int coins = 0;
            int roomCount = 0;

            List<string> rooms = Console.ReadLine().Split("|").ToList();

            for (int i = 0; i < rooms.Count; i++)
            {
                var elements = rooms[i].Split();

                string encounter = elements[0];
                int amount = int.Parse(elements[1]);

                switch (encounter)
                {
                    case "potion":
                        int healthNeeded = 100 - health;
                        if (amount > healthNeeded)
                        {
                            health = 100;
                            amount = healthNeeded;
                        }
                        else
                        {
                            health += amount;
                        }
                        Console.WriteLine($"You healed for {amount} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        roomCount++;
                        break;

                    case "chest":
                        coins += amount;
                        Console.WriteLine($"You found {amount} bitcoins.");
                        roomCount++;
                        break;

                    default:
                        health -= amount;
                        roomCount++;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {encounter}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {encounter}.");
                            Console.WriteLine($"Best room: {roomCount}");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {coins}");
            Console.WriteLine($"Health: {health}");

        }
    }
}
