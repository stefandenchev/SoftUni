using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"([#$%^&*])(?<name>[A-Za-z]+)(\1)=(?<number>\d+)!!(?<code>.+)");

            while (true)
            {
                string input = Console.ReadLine();

                Match match = validator.Match(input);

                if (!match.Success)
                {
                    Console.WriteLine("Nothing found!");
                }
                else
                {
                    int num = int.Parse(match.Groups["number"].Value);
                    int length = match.Groups["code"].Length;

                    if (num != length)
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }

                    List<char> characters = match.Groups["code"].Value.ToList();

                    for (int i = 0; i < characters.Count; i++)
                    {
                        characters[i] += (char)num;
                    }

                    Console.Write("Coordinates found! " + match.Groups["name"] + " -> ");
                    Console.Write(String.Join("", characters));
                    return;
                }
            }

        }
    }
}