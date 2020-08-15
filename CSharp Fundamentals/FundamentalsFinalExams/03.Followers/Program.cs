using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class data
    {
        public int Likes { get; set; }
        public int Comments { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, data> followers = new Dictionary<string, data>();
            string input = Console.ReadLine();

            while (input != "Log out")
            {
                var elements = input.Split(": ");
                var user = elements[1];

                if (input.Contains("New follower"))
                {
                    if (!followers.ContainsKey(user))
                    {
                        data followerInfo = new data() { Likes = 0, Comments = 0 };
                        followers.Add(user, followerInfo);
                    }
                }

                if (input.Contains("Like"))
                {
                    int count = int.Parse(elements[2]);
                    if (!followers.ContainsKey(user))
                    {
                        data followerInfo = new data() { Likes = count, Comments = 0 };
                        followers.Add(user, followerInfo);
                    }
                    else
                    {
                        followers[user].Likes += count;
                    }

                }

                if (input.Contains("Comment"))
                {
                    if (!followers.ContainsKey(user))
                    {
                        data followerInfo = new data() { Likes = 0, Comments = 1 };
                        followers.Add(user, followerInfo);
                    }
                    else
                    {
                        followers[user].Comments++;
                    }
                }

                if (input.Contains("Blocked"))
                {
                    if (followers.ContainsKey(user))
                    {
                        followers.Remove(user);
                    }
                    else
                    {
                        Console.WriteLine($"{user} doesn't exist.");
                    }
                }

                input = Console.ReadLine();

            }

            var sortedFollowers = followers.OrderByDescending(x => x.Value.Likes).ThenBy(x => x.Key);

            Console.WriteLine($"{followers.Count} followers");
            foreach (var fol in sortedFollowers)
            {
                Console.WriteLine($"{fol.Key}: {fol.Value.Comments + fol.Value.Likes}");
            }
                    
        }
    }
}