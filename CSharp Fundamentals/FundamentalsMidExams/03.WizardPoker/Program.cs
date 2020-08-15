using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.WizardPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine().Split(":").ToList();
            string input = Console.ReadLine();
            List<string> deck = new List<string>();

            while (input != "Ready")
            {
                var elements = input.Split();
                var command = elements[0];
                var card = elements[1];

                switch (command)
                {
                    case "Add":
                        if (cards.Contains(card))
                        {
                            deck.Add(card);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;

                    case "Insert":
                        var index = int.Parse(elements[2]);
                        if (index >= 0 && index <= deck.Count - 1 && cards.Contains(card))
                        {
                            deck.Insert(index, card);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;

                    case "Remove":
                        if (deck.Contains(card))
                        {
                            deck.Remove(card);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;

                    case "Swap":
                        var card2 = elements[2];
                        int index1 = deck.IndexOf(card);
                        int index2 = deck.IndexOf(card2);

                        deck.Insert(index1, card2);
                        deck.RemoveAt(index1 + 1);
                        deck.Insert(index2, card);
                        deck.RemoveAt(index2 + 1);

                        break;

                    case "Shuffle":
                        deck.Reverse();
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", deck));
        }
    }
}