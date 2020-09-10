using System;

namespace _01.UsernameRedo
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            string input = Console.ReadLine();

            while (!input.Contains("Sign up"))
            {
                var elements = input.Split();
                var command = elements[0];

                if (command.Contains("Case"))
                {
                    string size = elements[1];
                    if (size.Contains("lower"))
                    {
                        name = name.ToLower();
                    }
                    else
                    {
                        name = name.ToUpper();
                    }
                    Console.WriteLine(name);
                }

                if (command.Contains("Reverse"))
                {
                    int startIndex = int.Parse(elements[1]);
                    int endIndex = int.Parse(elements[2]);
                    if (startIndex >= 0 && startIndex <= name.Length - 1 && endIndex >= 0 && endIndex <= name.Length - 1)
                    {
                        var tempName = name.Substring(startIndex, endIndex - startIndex + 1);
                        var chars = tempName.ToCharArray();
                        Array.Reverse(chars);
                        tempName = new string(chars);
                        Console.WriteLine(tempName);
                    }
                }

                if (command.Contains("Cut"))
                {
                    var subS = elements[1];
                    if (name.Contains(subS))
                    {
                        var index = name.IndexOf(subS);
                        name = name.Remove(index, subS.Length);
                        Console.WriteLine(name);
                    }
                    else
                    {
                        Console.WriteLine($"The word {name} doesn't contain {subS}.");
                    }
                }

                if (command.Contains("Replace"))
                {
                    char ch = char.Parse(elements[1]);
                    name = name.Replace(ch, '*');
                    Console.WriteLine(name);
                }

                if (command.Contains("Check"))
                {
                    char ch = char.Parse(elements[1]);
                    if (name.Contains(ch))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {ch}.");
                    }
                }

                input = Console.ReadLine();
            }

        }
    }
}