using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split("|").Select(int.Parse).ToList();

            string input = Console.ReadLine();

            int points = 0;

            while (input != "Game over")
            {
                var elements = input.Split("@");

                string command = elements[0];

                switch (command)
                {
                    case "Shoot Left":
                        int index = int.Parse(elements[1]);
                        int length = int.Parse(elements[2]);

                        if (index >= 0 && index <= targets.Count - 1)
                        {
                            while (length != 0)
                            {
                                if (index > 0)
                                {
                                    index--;
                                    length--;
                                }
                                else if (index == 0)
                                {
                                    index = targets.Count - 1;
                                    length--;
                                }
                            }
                            if (targets[index] >= 5)
                            {
                                points += 5;
                                targets[index] -= 5;
                            }
                            else
                            {
                                points += targets[index];
                                targets[index] = 0;
                            }
                        }

                        break;

                    case "Shoot Right":
                        int index2 = int.Parse(elements[1]);
                        int length2 = int.Parse(elements[2]);

                        if (index2 >= 0 && index2 <= targets.Count - 1)
                        {
                            while (length2 != 0)
                            {
                                if (index2 < targets.Count - 1)
                                {
                                    index2++;
                                    length2--;
                                }
                                else if (index2 == targets.Count - 1)
                                {
                                    index2 = 0;
                                    length2--;
                                }
                            }
                            if (targets[index2] >= 5)
                            {
                                points += 5;
                                targets[index2] -= 5;
                            }
                            else
                            {
                                points += targets[index2];
                                targets[index2] = 0;
                            }

                        }
                        break;

                    case "Reverse":
                        targets.Reverse();
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}