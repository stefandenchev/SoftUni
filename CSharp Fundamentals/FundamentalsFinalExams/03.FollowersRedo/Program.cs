using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FollowersRedo
{
    class Stats
    {
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Stats> followers = new Dictionary<string, Stats>();
            string input = Console.ReadLine();

            while (!input.Contains("Log out"))
            {
                var elements = input.Split(": ");
                var command = elements[0];
                string userName = elements[1];

                if (command.Contains("New follower"))
                {
                    if (!followers.ContainsKey(userName))
                    {
                        Stats stats = new Stats { Likes = 0, Comments = 0 };
                        followers.Add(userName, stats);
                    }
                }

                if (command.Contains("Like"))
                {
                    int count = int.Parse(elements[2]);
                    if (followers.ContainsKey(userName))
                    {
                        followers[userName].Likes += count;
                    }
                    else
                    {
                        Stats stats = new Stats { Likes = count, Comments = 0 };
                        followers.Add(userName, stats);
                    }
                }

                if (command.Contains("Comment"))
                {
                    if (followers.ContainsKey(userName))
                    {
                        followers[userName].Comments++;
                    }
                    else
                    {
                        Stats stats = new Stats { Likes = 0, Comments = 1 };
                        followers.Add(userName, stats);
                    }
                }

                if (command.Contains("Blocked"))
                {
                    if (followers.ContainsKey(userName))
                    {
                        followers.Remove(userName);
                    }
                    else
                    {
                        Console.WriteLine($"{userName} doesn't exist.");
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(followers.Count + " followers");
            var sortedFollowers = followers.OrderByDescending(x => x.Value.Likes).ThenBy(x => x.Key);

            foreach (var follower in sortedFollowers)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value.Likes + follower.Value.Comments}");
            }
        }
    }
}