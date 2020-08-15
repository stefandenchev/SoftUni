using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MessagesManager
{
    class Messages
    {
        public int Sent { get; set; }
        public int Received { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Messages> users = new Dictionary<string, Messages>();
            int capacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                var elements = input.Split("=");
                var user = elements[1];

                if (input.Contains("Add"))
                {
                    if (!users.ContainsKey(user))
                    {
                        int sent = int.Parse(elements[2]);
                        int received = int.Parse(elements[3]);
                        Messages messages = new Messages { Sent = sent, Received = received };
                        users.Add(user, messages);
                    }
                }

                if (input.Contains("Message"))
                {
                    var receiver = elements[2];
                    if (users.ContainsKey(user) && users.ContainsKey(receiver))
                    {
                        users[user].Sent++;
                        if (users[user].Sent + users[user].Received == capacity)
                        {
                            users.Remove(user);
                            Console.WriteLine($"{user} reached the capacity!");
                        }

                        users[receiver].Received++;
                        if (users[receiver].Received + users[receiver].Sent == capacity)
                        {
                            users.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }

                if (input.Contains("Empty"))
                {
                    if (users.ContainsKey(user))
                    {
                        users.Remove(user);
                    }
                    if (user == "All")
                    {
                        users.Clear();
                    }

                }
                input = Console.ReadLine();
            }

            var sortedUsers = users.OrderByDescending(x => x.Value.Received).ThenBy(x => x.Key);

            Console.WriteLine($"Users count: {users.Count}");
            foreach (var user in sortedUsers)
            {
                Console.WriteLine($"{user.Key} - {user.Value.Received + user.Value.Sent}");
            }
        }
    }
}