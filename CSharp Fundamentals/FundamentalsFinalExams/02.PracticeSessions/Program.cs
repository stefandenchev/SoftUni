using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                var elements = input.Split("->");
                string road = elements[1];

                if (input.Contains("Add"))
                {
                    var racer = elements[2];
                    if (!data.ContainsKey(road))
                    {
                        data.Add(road, new List<string> { racer });
                    }
                    else
                    {
                        data[road].Add(racer);
                    }
                }

                if (input.Contains("Move"))
                {
                    var racer = elements[2];
                    var nextRoad = elements[3];
                    if (data[road].Contains(racer))
                    {
                        data[road].Remove(racer);
                        data[nextRoad].Add(racer);
                    }
                }

                if (input.Contains("Close"))
                {
                    if (data.ContainsKey(road))
                    {
                        data.Remove(road);
                    }
                }

                input = Console.ReadLine();
            }

            var sortedData = data.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            Console.WriteLine("Practice sessions:");
            foreach (var road in sortedData)
            {
                Console.WriteLine($"{road.Key}");
                for (int i = 0; i < road.Value.Count; i++)
                {
                    Console.WriteLine("++" + road.Value[i]);
                }
            }

        }
    }
}