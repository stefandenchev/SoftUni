using System;
using System.Collections.Generic;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var lightSide = new SortedDictionary<string, List<string>>();
            var darkSide = new SortedDictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                bool arrowSplit = false;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '-')
                    {
                        arrowSplit = true;
                        break;
                    }
                }

                if (arrowSplit)
                {
                    var elements = input.Split(" -> ");
                    string user = elements[0];
                    string side = elements[1];
                }
                else
                {
                    var elements = input.Split(" | ");
                    string side = elements[0];
                    string user = elements[1];

                    if (side.)
                    {

                    }
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