using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"^[0-9]+.+$");
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> Regular = new HashSet<string>();
            var input = Console.ReadLine();

            while (input != "PARTY")
            {
                Match match = validator.Match(input);
                if (match.Success)
                {
                    VIP.Add(input);
                }
                else
                {
                    Regular.Add(input);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "END")
            {
                if (VIP.Contains(input))
                {
                    VIP.Remove(input);
                }
                if (Regular.Contains(input))
                {
                    Regular.Remove(input);
                }

                input = Console.ReadLine();
            }

            int sum = VIP.Count + Regular.Count;
            Console.WriteLine(sum);

            foreach (var guest in VIP)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in Regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}