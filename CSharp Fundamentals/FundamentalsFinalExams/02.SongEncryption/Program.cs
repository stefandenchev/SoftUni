using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validator = new Regex(@"^(?<artist>[A-Z][a-z ']+):(?<song>[A-Z ]+)$");
            string input = Console.ReadLine();

            while (input != "end")
            {
                Match match = validator.Match(input);

                if (match.Success)
                {
                    Console.Write("Successful encryption: ");
                    int key = match.Groups["artist"].Length;
                    var charArr1 = match.Groups["artist"].Value.ToList();
                    var charArr2 = match.Groups["song"].Value.ToList();

                    List<char> characters = new List<char>();

                    for (int i = 0; i < key; i++)
                    {
                        characters.Add(match.Groups["artist"].Value[i]);
                    }
                    characters.Add('@');
                    for (int i = 0; i < match.Groups["song"].Length; i++)
                    {
                        characters.Add(match.Groups["song"].Value[i]);
                    }

                    for (int i = 0; i < characters.Count; i++)
                    {
                        char curr = characters[i];
                        if (curr == '@' || curr == '\'' || curr == ' ')
                        {
                            Console.Write(curr);
                            continue;
                        }
                        if (curr >= 65 && curr <= 90)
                        {
                            if (curr + key > 90)
                            {
                                int toEnd = 90 - curr + 1;
                                int rem = key - toEnd;
                                curr = 'A';
                                curr += (char)rem;
                            }
                            else
                            {
                                curr += (char)key;
                            }
                            Console.Write(curr);
                        }
                        else
                        {
                            if (curr + key > 122)
                            {
                                int toEnd = 122 - curr + 1;
                                int rem = key - toEnd;
                                curr = 'a';
                                curr += (char)rem;
                            }
                            else
                            {
                                curr += (char)key;
                            }
                            Console.Write(curr);
                        }
                    }
                        Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


                input = Console.ReadLine();
            }
        }
    }
}