using System;
using System.Text.RegularExpressions;

namespace _02.MessageEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"([*@])(?<tag>[A-Z][a-z][a-z]+)(\1): \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|$");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = validator.Match(input);
                if (match.Success)
                {
                    char num1 = char.Parse(match.Groups[3].Value);
                    char num2 = char.Parse(match.Groups[4].Value);
                    char num3 = char.Parse(match.Groups[5].Value);

                    Console.WriteLine($"{match.Groups["tag"]}: {(int)num1} {(int)num2} {(int)num3}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}