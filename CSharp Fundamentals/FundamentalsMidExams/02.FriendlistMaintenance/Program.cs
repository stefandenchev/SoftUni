using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.FriendlistMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            int blacklistCount = 0;
            int lostCount = 0;

            while (input != "Report")
            {
                var elements = input.Split();
                var command = elements[0];

                switch (command)
                {
                    case "Blacklist":
                        var name = elements[1];
                        if (friends.Contains(name))
                        {
                            friends[friends.IndexOf(name)] = "Blacklisted";
                            Console.WriteLine($"{name} was blacklisted.");
                            blacklistCount++;
                        }
                        else
                        {
                            Console.WriteLine($"{name} was not found.");

                        }
                        break;

                    case "Error":
                        int index = int.Parse(elements[1]);

                        if (friends.ElementAt(index) != "Blacklisted" && friends.ElementAt(index) != "Lost")
                        {
                            string lostName = friends.ElementAt(index);
                            friends[friends.IndexOf(lostName)] = "Lost";

                            Console.WriteLine($"{lostName} was lost due to an error.");
                            lostCount++;

                        }
                        break;

                    case "Change":
                        int indexChange = int.Parse(elements[1]);
                        string newName = elements[2];

                        if (indexChange >= 0 && indexChange <= friends.Count - 1)
                        {
                            string oldName = friends.ElementAt(indexChange);
                            friends.RemoveAt(indexChange);
                            friends.Insert(indexChange, newName);
                            Console.WriteLine($"{oldName} changed his username to {newName}.");
                        }

                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: {blacklistCount}");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(String.Join(" ", friends));
        }
    }
}
