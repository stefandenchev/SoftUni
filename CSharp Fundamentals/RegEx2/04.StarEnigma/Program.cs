using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Match> attacked = new List<Match>();
            List<Match> destroyed = new List<Match>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"[SsTtAaRr]";

                var matches = Regex.Matches(input, pattern);
                int count = matches.Count;

                string decryptedMsg = String.Empty;

                foreach (var character in input)
                {
                    decryptedMsg += (char)(character - count);
                }

                Console.WriteLine(decryptedMsg);
                string pattern2 = @"^[^@\-!:>]*@(?<planetName>[a-zA-Z]+)[^@\-!:>]*:[^@\-!:>]*?(?<populationCount>\d+)[^@\-!:>]*![^@\-!:>]*(?<attackType>[AD])![^@\-!:>]*->(?<soldierCount>\d+)[^@\-!:>]*$";

            }

        }
    }
}