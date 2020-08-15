using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace fkmesideways
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"([=\/])(?<destination>[A-Z][A-Za-z]{2,})(\1)");
            string input = Console.ReadLine();

            MatchCollection matches = validator.Matches(input);

            int travelPoints = 0;
            List<string> validDestinations = new List<string>();

            foreach (Match match in matches)
            {
                travelPoints += match.Groups["destination"].Length;
                validDestinations.Add(match.Groups["destination"].Value);
            }

            Console.WriteLine($"Destinations: {String.Join(", ", validDestinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}