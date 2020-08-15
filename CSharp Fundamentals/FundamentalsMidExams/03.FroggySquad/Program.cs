using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FroggySquad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();

            while (true)
            {
                var elements = input.Split();
                var command = elements[0];

                if (command == "Print")
                {
                    var direction = elements[1];
                    if (direction == "Normal")
                    {
                        Console.Write("Frogs: ");
                        Console.WriteLine(String.Join(" ", frogs));
                    }
                    else
                    {
                        frogs.Reverse();
                        Console.Write("Frogs: ");
                        Console.WriteLine(String.Join(" ", frogs));
                    }
                    return;
                }

                switch (command)
                {
                    case "Join":
                        var newFrog = elements[1];
                        frogs.Add(newFrog);
                        break;

                    case "Jump":
                        var frog = elements[1];
                        var index = int.Parse(elements[2]);
                        if (index >= 0 && index <= frogs.Count - 1)
                        {
                            frogs.Insert(index, frog);
                        }

                        break;

                    case "Dive":
                        var indexDive = int.Parse(elements[1]);
                        if (indexDive >= 0 && indexDive <= frogs.Count - 1)
                        {
                            frogs.RemoveAt(indexDive);
                        }

                        break;

                    case "First":
                        var count = int.Parse(elements[1]);
                        if (count > frogs.Count)
                        {
                            Console.WriteLine(String.Join(" ", frogs));
                        }
                        else
                        {
                            for (int i = 0; i < count - 1; i++)
                            {
                                Console.Write(frogs[i] + " ");
                            }
                            for (int i = count - 1; i <= count - 1; i++)
                            {
                                Console.WriteLine(frogs[i] + " ");
                            }
                        }
                        break;

                    case "Last":
                        var countLast = int.Parse(elements[1]);
                        if (countLast > frogs.Count)
                        {
                            Console.WriteLine(String.Join(" ", frogs));
                        }
                        else
                        {
                            for (int i = frogs.Count - countLast; i <= frogs.Count - 2; i++)
                            {
                                Console.Write(frogs[i] + " ");
                            }
                            for (int i = frogs.Count - 1; i <= frogs.Count - 1; i++)
                            {
                                Console.WriteLine(frogs[i] + " ");
                            }
                        }
                        break;
                }
                input = Console.ReadLine();
            }

        }
    }
}