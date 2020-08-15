using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            // GIVES 80/100!!! // GIVES 80/100!!! // GIVES 80/100!!!
            // GIVES 80/100!!! // GIVES 80/100!!! // GIVES 80/100!!!
            // GIVES 80/100!!! // GIVES 80/100!!! // GIVES 80/100!!!

            Regex validator = new Regex(@"([:]{2}|[*]{2})([A-Z][a-z]{2,})(\1)");
            string input = Console.ReadLine();
            List<string> digits = new List<string>();
            List<string> matches = new List<string>();
            List<string> coolMatches = new List<string>();

            BigInteger coolThreshold = 1;

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    digits.Add(input[i].ToString());
                }
            }

            foreach (var digit in digits)
            {
                int value = int.Parse(digit);
                coolThreshold *= value;
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");

            //Match match = regex.Match(input);

            MatchCollection emojis = validator.Matches(input);

            foreach (Match match in emojis)
            {
                string emoji = match.Groups[0].Value;
                matches.Add(emoji);
            }
            
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (var emoji in matches)
            {
                BigInteger coolness = 0;
                for (int i = 0; i < emoji.Length; i++)
                {
                    coolness += emoji[i];
                }
                if (coolness > coolThreshold)
                {
                    coolMatches.Add(emoji);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, coolMatches));

        }
    }
}