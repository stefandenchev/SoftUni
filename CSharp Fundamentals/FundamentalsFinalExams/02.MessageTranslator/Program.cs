using System;
using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex pattern = new Regex(@"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})\]");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = pattern.Match(input);
                if (match.Success)
                {
                    Console.Write($"{match.Groups["command"].Value}: ");

                    var charArr = match.Groups["message"].Value;

                    for (int j = 0; j < charArr.Length; j++)
                    {
                        Console.Write((int)charArr[j] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }
            }
        }
    }
}