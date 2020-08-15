using System;

namespace _01.StringManipulatorG2
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Done")
            {
                var elements = input.Split();
                if (input.Contains("Change"))
                {
                    var ch = char.Parse(elements[1]);
                    var replacement = char.Parse(elements[2]);

                    message = message.Replace(ch, replacement);
                    Console.WriteLine(message);
                }

                if (input.Contains("Includes"))
                {
                    var str = elements[1];
                    if (message.Contains(str))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                if (input.Contains("End"))
                {
                    var str = elements[1];
                    /*var length = str.Length;

                    var substring = message.Substring(message.Length - length);
                    if (str == substring)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }*/

                    if (message.EndsWith(str))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                if (input.Contains("Uppercase"))
                {
                    message = message.ToUpper();
                    Console.WriteLine(message);
                }

                if (input.Contains("FindIndex"))
                {
                    var ch = char.Parse(elements[1]);
                    int index = message.IndexOf(ch);
                    Console.WriteLine(index);
                }

                if (input.Contains("Cut"))
                {
                    int index = int.Parse(elements[1]);
                    int length = int.Parse(elements[2]);

                    string sub = message.Substring(index, length);
                    message = sub;

                    Console.WriteLine(message);
                }

                input = Console.ReadLine();
            }
        }
    }
}