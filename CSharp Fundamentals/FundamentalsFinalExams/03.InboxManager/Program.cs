using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                var elements = input.Split("->");
                string user = elements[1];

                if (input.Contains("Add"))
                {
                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{user} is already registered");
                    }
                }

                if (input.Contains("Send"))
                {
                    string email = elements[2];
                    users[user].Add(email);
                }

                if (input.Contains("Delete"))
                {
                    if (!users.ContainsKey(user))
                    {
                        Console.WriteLine($"{user} not found!");
                    }
                    else
                    {
                        users.Remove(user);
                    }
                }

                input = Console.ReadLine();
            }

            var sortedUsers = users.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            Console.WriteLine($"Users count: {users.Count}");
            foreach (var user in sortedUsers)
            {
                Console.WriteLine(user.Key);
                //Console.WriteLine(String.Join(" - " + Environment.NewLine, user.Value)); nah fam
                for (int i = 0; i < user.Value.Count; i++)
                {
                    Console.WriteLine(" - " + user.Value[i]);
                }
            }

        }
    }
}