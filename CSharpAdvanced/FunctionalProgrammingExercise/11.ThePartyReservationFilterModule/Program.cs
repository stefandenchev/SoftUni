using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();
            List<string> filters = new List<string>();

            while (input != "Print")
            {
                string[] elements = input.Split(";");
                string command = elements[0];
                string filter = elements[1];
                string argument = elements[2];

                if (command == "Add filter")
                {
                    filters.Add($"{filter};{argument}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{filter};{argument}");
                }

                input = Console.ReadLine();
            }
            foreach (var filterLine in filters)
            {
                var elements = filterLine.Split(";");
                var filterType = elements[0];
                var argument = elements[1];

                switch (filterType)
                {
                    case "Starts with":
                        people = people.Where(p => !p.StartsWith(argument)).ToList();
                        break;

                    case "Ends with":
                        people = people.Where(p => !p.EndsWith(argument)).ToList();
                        break;

                    case "Length":
                        people = people.Where(p => p.Length != int.Parse(argument)).ToList();
                        break;

                    case "Contains":
                        people = people.Where(p => !p.Contains(argument)).ToList();
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", people));
        }
    }
}
