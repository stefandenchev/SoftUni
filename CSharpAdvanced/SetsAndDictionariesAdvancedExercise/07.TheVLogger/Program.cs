using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Vlogger> vloggers = new HashSet<Vlogger>();
            var input = Console.ReadLine().Split().ToArray();

            while (input[0] != "Statistics")
            {
                switch (input[1])
                {
                    case "joined":
                        Vlogger vlogger = new Vlogger(input[0]);
                        if (!vloggers.Any(x => x.Name == vlogger.Name))
                        {
                            vloggers.Add(vlogger);
                        }
                        break;

                    case "followed":
                        var following = input[0];
                        var followed = input[2];

                        if (following != followed && vloggers.Any(x => x.Name == following) && vloggers.Any(x => x.Name == followed))
                        {
                            Vlogger vlogger1 = vloggers.Where(x => x.Name == following).FirstOrDefault();
                            vlogger1.AddFollowing(followed);
                            Vlogger vlogger2 = vloggers.Where(x => x.Name == followed).FirstOrDefault();
                            vlogger2.AddFollower(following);

                        }
                        break;
                }
                input = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            if (vloggers.Count == 0)
            {
                return;
            }

            int maxFollowers = int.MinValue;

            foreach (var vlogger in vloggers)
            {
                if (vlogger.Followers.Count > maxFollowers)
                {
                    maxFollowers = vlogger.Followers.Count;
                } 
            }

            var mostFamous = vloggers.Where(x => x.Followers.Count == maxFollowers);
            var famous = mostFamous.OrderBy(x => x.Followings.Count).FirstOrDefault();

            Console.WriteLine($"1. {famous.Name} : {famous.Followers.Count} followers, {famous.Followings.Count} following");

            foreach (var follower in famous.Followers)
            {
                Console.WriteLine($"*  {follower}");
            }
            vloggers.Remove(famous);

            var sorted = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Followings.Count);

            int counter = 2;
            foreach (var vlogger in sorted)
            {
                Console.WriteLine($"{counter}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Followings.Count} following");
                counter++;
            }
        }
    }

    public class Vlogger
    {
        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Followings { get; set; }

        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new SortedSet<string>();
            this.Followings = new HashSet<string>();
        }

        public void AddFollower(string name)
        {
            Followers.Add(name);
        }

        public void AddFollowing(string name)
        {
            Followings.Add(name);
        }
    }

}