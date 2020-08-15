using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ContactList
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> contactList = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (true)
            {
                var elements = input.Split();

                string command = elements[0];

                switch (command)
                {
                    case "Add":
                        var contact = elements[1];
                        var indexToAdd = int.Parse(elements[2]);
                        if (!contactList.Contains(contact))
                        {
                            contactList.Add(contact);
                        }
                        else
                        {
                            if (indexToAdd >= 0 && indexToAdd <= contactList.Count - 1)
                            {
                                contactList.Insert(indexToAdd, contact);
                            }
                        }
                        break;

                    case "Remove":
                        var indexToRemove = int.Parse(elements[1]);
                        if (indexToRemove >= 0 && indexToRemove <= contactList.Count - 1)
                        {
                            contactList.RemoveAt(indexToRemove);
                        }
                        break;

                    case "Export":
                        var startIndex = int.Parse(elements[1]);
                        var count = int.Parse(elements[2]);

                        if (startIndex + count < contactList.Count)
                        {
                            for (int i = startIndex; i < startIndex + count; i++)
                            {
                                Console.Write(contactList[i] + " ");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            for (int i = startIndex; i < contactList.Count; i++)
                            {
                                Console.Write(contactList[i] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case "Print":
                        var direction = elements[1];
                        if (direction == "Reversed")
                        {
                            contactList.Reverse();
                        }
                        Console.Write("Contacts: ");
                        Console.WriteLine(String.Join(" ", contactList));
                        return;

                }
                input = Console.ReadLine();
            }
        }
    }
}