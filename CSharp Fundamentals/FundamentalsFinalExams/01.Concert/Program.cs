using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Concert
{
    class Band
    {
        public List<string> Members { get; set; }
        public int Time { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Band> bands = new Dictionary<string, Band>();
            int totalTime = 0;

            string input = Console.ReadLine();

            while (input != "start of concert")
            {
                var elements = input.Split("; ");
                var bandName = elements[1];

                if (input.Contains("Add"))
                {
                    var members = new List<string>();
                    var individuals = elements[2].Split(", ");
                    for (int i = 0; i < individuals.Length; i++)
                    {
                        if (!members.Contains(individuals[i]))
                        {
                            members.Add(individuals[i]);
                        }
                    }

                    if (!bands.ContainsKey(bandName))
                    {
                        Band band = new Band { Members = members, Time = 0 };
                        bands.Add(bandName, band);
                    }
                    else
                    {
                        for (int i = 0; i < members.Count; i++)
                        {
                            if (!bands[bandName].Members.Contains(members[i]))
                            {
                                bands[bandName].Members.Add(members[i]);
                            }
                        }
                    }
                }

                if (input.Contains("Play"))
                {
                    var time = int.Parse(elements[2]);
                    if (!bands.ContainsKey(bandName))
                    {
                        Band band = new Band { Members = new List<string>(), Time = time };
                        bands.Add(bandName, band);
                    }
                    else
                    {
                        bands[bandName].Time += time;
                    }
                    totalTime += time;
                }

                input = Console.ReadLine();
            }

            var sortedBands = bands.OrderByDescending(x => x.Value.Time).ThenBy(x => x.Key);

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var band in sortedBands)
            {
                Console.WriteLine($"{band.Key} -> {band.Value.Time}");
            }

            string bandChoice = Console.ReadLine();

            int n = bands[bandChoice].Members.Count;

            Console.WriteLine(bandChoice);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"=> {bands[bandChoice].Members[i]}");
            }

        }
    }
}