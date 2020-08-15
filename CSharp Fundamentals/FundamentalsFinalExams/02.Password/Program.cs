using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^,;]{3})<(\1)");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = validator.Match(input);

                if (match.Success)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 2; j <= 5; j++)
                    {
                        sb.Append(match.Groups[j]);
                    }
                    Console.WriteLine($"Password: {sb}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}