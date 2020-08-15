using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                var elements = input.Split(" - ");

                string command = elements[0];
                string item = elements[1];

                switch (command)
                {
                    case "Collect":
                        if (!items.Contains(item))
                        {
                            items.Add(item);
                        }
                        break;

                    case "Drop":
                        if (items.Contains(item))
                        {
                            items.Remove(item);
                        }
                        break;

                    case "Combine Items":
                        var pieces = item.Split(":");
                        string oldItem = pieces[0];
                        string newItem = pieces[1];

                        if (items.Contains(oldItem))
                        {
                            int indexOfOld = items.IndexOf(oldItem);
                            items.Insert(indexOfOld + 1, newItem);
                        }
                        break;

                    case "Renew":
                        if (items.Contains(item))
                        {
                            string temp = item;
                            items.Remove(item);
                            items.Add(temp);
                        }
                        break;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", items));

        }
    }
}
