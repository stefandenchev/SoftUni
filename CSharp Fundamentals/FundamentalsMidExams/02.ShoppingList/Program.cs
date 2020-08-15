using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!").ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                var elements = input.Split();

                string command = elements[0];
                string product = elements[1];

                switch (command)
                {
                    case "Urgent":
                        if (!groceries.Contains(product))
                        {
                            groceries.Insert(0, product);
                        }
                        break;

                    case "Unnecessary":
                        if (groceries.Contains(product))
                        {
                            groceries.Remove(product);
                        }
                        break;

                    case "Correct":
                        string newItem = elements[2];
                        if (groceries.Contains(product))
                        {
                            int index = groceries.IndexOf(product);
                            groceries[index] = newItem;
                        }

                        break;

                    case "Rearrange":
                        if (groceries.Contains(product))
                        {
                            int index = groceries.IndexOf(product);
                            string item = groceries[index];
                            groceries.RemoveAt(index);
                            groceries.Add(item);
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", groceries));
        }
    }
}
