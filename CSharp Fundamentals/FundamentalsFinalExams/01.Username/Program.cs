using System;
using System.Linq;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Sign up")
            {
                var elements = input.Split();
                if (input.Contains("Case"))
                {
                    var size = elements[1];
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

                if (input.Contains("Reverse"))
                {
                    int start = int.Parse(elements[1]);
                    int end = int.Parse(elements[2]);

                    if (start >= 0 && start <= name.Length - 1 && end >= 0 && end <= name.Length - 1)
                    {
                        string sub = name.Substring(start, end - start + 1);
                        var reversed = new string(sub.Reverse().ToArray());
                        Console.WriteLine(reversed);
                    }
                }

                if (input.Contains("Cut"))
                {
                    var sub = elements[1];
                    if (name.Contains(sub))
                    {
                        int index = name.IndexOf(sub);
                        name = name.Remove(index, sub.Length);
                        Console.WriteLine(name);
                    }
                    else
                    {
                        Console.WriteLine($"The word {name} doesn't contain {sub}.");
                    }
                }

                if (input.Contains("Replace"))
                {
                    var ch = char.Parse(elements[1]);
                    name = name.Replace(ch, '*');
                    Console.WriteLine(name);
                }

                if (input.Contains("Check"))
                {
                    var ch = char.Parse(elements[1]);
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