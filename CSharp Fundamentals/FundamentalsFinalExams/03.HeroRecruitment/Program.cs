using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                var elements = input.Split();
                if (input.Contains("Enroll"))
                {
                    var name = elements[1];
                    if (!heroes.ContainsKey(name))
                    {
                        heroes.Add(name, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already enrolled.");
                    }
                }

                if (input.Contains("Learn"))
                {
                    var name = elements[1];
                    var spell = elements[2];

                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (heroes[name].Contains(spell))
                        {
                            Console.WriteLine($"{name} has already learnt {spell}.");
                        }
                        else
                        {
                            heroes[name].Add(spell);
                        }
                    }
                }

                if (input.Contains("Unlearn"))
                {
                    var name = elements[1];
                    var spell = elements[2];

                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (!heroes[name].Contains(spell))
                        {
                            Console.WriteLine($"{name} doesn't know {spell}.");
                        }
                        else
                        {
                            heroes[name].Remove(spell);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var heroesSorted = heroes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            Console.WriteLine("Heroes:");

            foreach (var hero in heroesSorted)
            {
                Console.WriteLine($"== {hero.Key}: {String.Join(", ", hero.Value)}");
            }
        }
    }
}