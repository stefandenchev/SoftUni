using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"([@#])(?<word1>[A-Za-z]{3,})\1{2}(?<word2>[A-Za-z]{3,})\1");
            string input = Console.ReadLine();
            List<string> matches = new List<string>();

            MatchCollection words = regex.Matches(input);
            int matchCounter = 0;

            foreach (Match match in words)
            {
                if (match.Success)
                {
                    string firstWord = match.Groups["word1"].Value;
                    string secondWord = match.Groups["word2"].Value;

                    var charArr = secondWord.ToCharArray();
                    Array.Reverse(charArr);
                    string secondReversed = new string(charArr);

                    if (firstWord == secondReversed)
                    {
                        string mirror = firstWord + " <=> " + secondWord;
                        matches.Add(mirror);
                    }
                    matchCounter++;
                }
            }

            if (words.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchCounter} word pairs found!");
            }
            if (matches.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", matches));
            }

        }
    }
}