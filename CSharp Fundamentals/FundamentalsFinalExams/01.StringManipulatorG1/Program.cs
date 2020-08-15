using System;

namespace _01.StringManipulatorG1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "End")
            {
                var elements = input.Split();
                if (input.Contains("Translate"))
                {
                    var oldCharacter = char.Parse(elements[1]);
                    var replacement = char.Parse(elements[2]);

                    message = message.Replace(oldCharacter, replacement);
                    Console.WriteLine(message);
                }

                if (input.Contains("Includes"))
                {
                    var stringToCheck = elements[1];
                    if (message.Contains(stringToCheck))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                if (input.Contains("Start"))
                {
                    var startCheck = elements[1];
                    if (message.StartsWith(startCheck))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                if (input.Contains("Lowercase"))
                {
                    message = message.ToLower();
                    Console.WriteLine(message);
                }

                if (input.Contains("FindIndex"))
                {
                    var ch = char.Parse(elements[1]);
                    var index = message.LastIndexOf(ch);
                    Console.WriteLine(index);
                }

                if (input.Contains("Remove"))
                {
                    int startIndex = int.Parse(elements[1]);
                    int count = int.Parse(elements[2]);

                    message = message.Remove(startIndex, count);
                    Console.WriteLine(message);
                }
                    input = Console.ReadLine();

            }
        }
    }
}