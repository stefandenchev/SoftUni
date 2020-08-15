using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NikuldensMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            int unlikedMeals = 0;

            while (input != "Stop")
            {
                var elements = input.Split("-");
                var guest = elements[1];
                var meal = elements[2];

                if (input.Contains("Like"))
                {
                    if (!guests.ContainsKey(guest))
                    {
                        guests.Add(guest, new List<string>() { meal });
                    }
                    else
                    {
                        if (!guests[guest].Contains(meal))
                        {
                            guests[guest].Add(meal);
                        }
                    }
                }

                if (input.Contains("Unlike"))
                {
                    if (!guests.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        if (!guests[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            guests[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            unlikedMeals++;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var sortedGuests = guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var guest in sortedGuests)
            {
                Console.Write($"{guest.Key}: {String.Join(", ", guest.Value)}");
                Console.WriteLine();
            }
            Console.WriteLine($"Unliked meals: {unlikedMeals}");

        }
    }
}