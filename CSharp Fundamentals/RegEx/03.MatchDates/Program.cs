using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string pattern = @"[0-9]{2}(.)[A-Za-z]{3}\1\d{4}";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();*/

            MatchCollection dates = Regex.Matches(Console.ReadLine(), @"(?<day>[0-9]{2})(.)(?<month>[A-Za-z]{3})\1(\d{4})");

            foreach (Match date in dates)
            {
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups[2]}");
            }
        }
    }
}