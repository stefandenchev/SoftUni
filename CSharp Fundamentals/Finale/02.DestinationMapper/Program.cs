using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string validator = @"([=\/])(?<destination>[A-Z]{1}[a-z]{2,})(\1)";
            string input = Console.ReadLine();
            int travelPoints = 0;

            MatchCollection matches = Regex.Matches(input, validator);
            var validDestinations = matches.Cast<Match>().Select(match => match.Value).ToList();

            foreach (Match destination in matches)
            {
                travelPoints += destination.Value.Length - 2;
            }

            for (int i = 0; i < validDestinations.Count; i++)
            {
                validDestinations[i] = validDestinations[i].Remove(0, 1);
                validDestinations[i] = validDestinations[i].Remove(validDestinations[i].Length - 1, 1);
            }

            Console.WriteLine($"Destinations: {String.Join(", ", validDestinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");

        }
    }
}