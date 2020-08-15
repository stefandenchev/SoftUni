using System;

namespace _01.NikuldensCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Finish")
            {
                var elements = input.Split();
                if (input.Contains("Replace"))
                {
                    var currentChar = elements[1];
                    var newChar = elements[2];

                    message = message.Replace(currentChar, newChar);
                    Console.WriteLine(message);
                }

                if (input.Contains("Cut"))
                {
                    var startIndex = int.Parse(elements[1]);
                    var endIndex = int.Parse(elements[2]);

                    if ((startIndex >= 0 && startIndex <= message.Length - 1) && (endIndex >= 0 && endIndex <= message.Length - 1))
                    {
                        message = message.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }

                if (input.Contains("Make"))
                {
                    var size = elements[1];
                    if (size.Contains("Upper"))
                    {
                        message = message.ToUpper();
                    }
                    else
                    {
                        message = message.ToLower();
                    }
                    Console.WriteLine(message);
                }

                if (input.Contains("Check"))
                {
                    string checkString = elements[1];
                    if (message.Contains(checkString))
                    {
                        Console.WriteLine($"Message contains {checkString}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {checkString}");
                    }
                }

                if (input.Contains("Sum"))
                {
                    var startIndex = int.Parse(elements[1]);
                    var endIndex = int.Parse(elements[2]);

                    if ((startIndex >= 0 && startIndex <= message.Length - 1) && (endIndex >= 0 && endIndex <= message.Length - 1))
                    {
                        string substring = new string(message.Substring(startIndex, endIndex - startIndex + 1));
                        int sum = 0;
                        foreach (char ch in substring)
                        {
                            sum += ch;
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}