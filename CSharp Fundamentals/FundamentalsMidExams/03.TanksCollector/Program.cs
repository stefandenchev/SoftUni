using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TanksCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tanks = Console.ReadLine().Split(", ").ToList();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();

                var elements = input.Split(", ");
                var command = elements[0];

                switch (command)
                {
                    case "Add":
                        var tankToAdd = elements[1];
                        if (tanks.Contains(tankToAdd))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            tanks.Add(tankToAdd);
                            Console.WriteLine("Tank successfully bought");
                        }
                        break;

                    case "Remove":
                        var tankToRemove = elements[1];
                        if (tanks.Contains(tankToRemove))
                        {
                            tanks.Remove(tankToRemove);
                            Console.WriteLine("Tank successfully sold");
                        }
                        else
                        {
                            Console.WriteLine("Tank not found");
                        }
                        break;

                    case "Remove At":
                        var indexToRemove = int.Parse(elements[1]);

                        if (indexToRemove >= 0 && indexToRemove <= tanks.Count - 1)
                        {
                            tanks.RemoveAt(indexToRemove);
                            Console.WriteLine("Tank successfully sold");
                        }
                        else
                        {
                            Console.WriteLine("Index out of range");
                        }
                        break;

                    case "Insert":
                        var indexToInsert = int.Parse(elements[1]);
                        var tankName = elements[2];

                        if (indexToInsert >= 0 && indexToInsert <= tanks.Count - 1)
                        {
                            if (!tanks.Contains(tankName))
                            {
                                tanks.Insert(indexToInsert, tankName);
                                Console.WriteLine("Tank successfully bought");
                            }
                            else
                            {
                                Console.WriteLine("Tank is already bought");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Index out of range");
                        }

                        break;
                }

            }

            Console.WriteLine(String.Join(", ", tanks));

        }
    }
}