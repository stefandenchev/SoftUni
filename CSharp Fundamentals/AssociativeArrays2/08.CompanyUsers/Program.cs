using System;
using System.Collections.Generic;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var elements = input.Split(" -> ");
                string name = elements[0];
                string id = elements[1];

                if (!companies.ContainsKey(name))
                {
                    companies.Add(name, new List<string>());
                    companies[name].Add(id);
                }
                else
                {
                    List<string> ids = companies[name];
                    if (!ids.Contains(id))
                    {
                        companies[name].Add(id);
                    }
                }
            }

            foreach (var pair in companies)
            {
                Console.WriteLine(pair.Key);
                foreach (string id in pair.Value)
                {
                    Console.WriteLine("-- " + id);
                }
            }
        }
    }
}