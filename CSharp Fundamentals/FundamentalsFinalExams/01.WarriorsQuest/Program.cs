using System;

namespace _01.WarriorsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "For Azeroth")
            {
                var elements = command.Split();

                if (command.Contains("GladiatorStance"))
                {
                    skill = skill.ToUpper();
                    Console.WriteLine(skill);
                }

                else if (command.Contains("DefensiveStance"))
                {
                    skill = skill.ToLower();
                    Console.WriteLine(skill);
                }

                else if (command.Contains("Dispel"))
                {
                    int index = int.Parse(elements[1]);
                    var letter = elements[2];

                    if (index >= 0 && index <= skill.Length - 1)
                    {
                        skill = skill.Remove(index, 1);
                        skill = skill.Insert(index, letter);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }

                else if (command.Contains("Target Change"))
                {
                    var substring = elements[2];
                    var substring2 = elements[3];

                    skill = skill.Replace(substring, substring2);
                    Console.WriteLine(skill);
                }

                else if (command.Contains("Target Remove"))
                {
                    string substring = elements[2];
                    int index = skill.IndexOf(substring);

                    skill = skill.Remove(index, substring.Length);
                    Console.WriteLine(skill);
                }

                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

                command = Console.ReadLine();
            }

        }
    }
}