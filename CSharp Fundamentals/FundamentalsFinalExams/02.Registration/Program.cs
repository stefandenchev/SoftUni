using System;
using System.Text.RegularExpressions;

namespace _02.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"U\$(?<name>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}\d+)P@\$");
            int n = int.Parse(Console.ReadLine());
            int successfulRegistrations = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = validator.Match(input);

                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["name"]}, Password: {match.Groups["password"]}");
                    successfulRegistrations++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successfulRegistrations}");
        }
    }
}