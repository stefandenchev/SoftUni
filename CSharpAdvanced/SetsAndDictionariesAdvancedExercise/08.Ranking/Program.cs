using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string contestInput = Console.ReadLine();
                if (contestInput == "end of contests")
                {
                    break;
                }
                var elements = contestInput.Split(":");
                var contest = elements[0];
                var password = elements[1];

                contests.Add(contest, password);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }

                var elements = input.Split("=>");
                var contest = elements[0];
                var password = elements[1];
                var name = elements[2];
                var points = int.Parse(elements[3]);

                if (contests.ContainsKey(contest) && contests[contest].Contains(password))
                {
                    if (!candidates.ContainsKey(name))
                    {
                        candidates.Add(name, new Dictionary<string, int>());
                        candidates[name].Add(contest, points);
                    }
                    else if (candidates.ContainsKey(name) && !candidates[name].ContainsKey(contest))
                    {
                        candidates[name].Add(contest, points);
                    }
                    else if (candidates.ContainsKey(name)
                        && candidates[name].ContainsKey(contest)
                        && candidates[name][contest] < points)
                    {
                        candidates[name][contest] = points;
                    }
                }

            }

            string bestName = String.Empty;
            int bestPoints = 0;

            foreach (var candidate in candidates)
            {
                int points = 0;
                foreach (var contest in candidate.Value)
                {
                    points += contest.Value;
                }
                if (points > bestPoints)
                {
                    bestPoints = points;
                    bestName = candidate.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}