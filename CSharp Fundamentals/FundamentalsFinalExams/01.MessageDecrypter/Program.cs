using System;
using System.Text.RegularExpressions;

namespace _02.MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"^([%$])(?<tag>[A-Z][a-z]{2,})(\1): \[([\d]+)\]\|\[([\d]+)\]\|\[([\d]+)\]\|$");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = validator.Match(input);

                if (match.Success)
                {
                    int sym1 = int.Parse(match.Groups[3].Value);
                    int sym2 = int.Parse(match.Groups[4].Value);
                    int sym3 = int.Parse(match.Groups[5].Value);

                    Console.WriteLine($"{match.Groups["tag"]}: {(char)sym1}{(char)sym2}{(char)sym3}");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}