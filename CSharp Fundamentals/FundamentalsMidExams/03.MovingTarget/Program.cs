using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] elements = input.Split();

                string command = elements[0];
                int index = int.Parse(elements[1]);

                switch (command)
                {
                    case "Shoot":
                        int power = int.Parse(elements[2]);

                        if (index >= 0 && index <= targets.Count - 1)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;

                    case "Add":
                        int value = int.Parse(elements[2]);

                        if (index >= 0 && index <= targets.Count - 1)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                            break;
                        }
                        break;

                    case "Strike":
                        int radius = int.Parse(elements[2]);

                        if (index >= 0 && index <= targets.Count - 1)
                        {
                            if (index - radius >= 0 && index + radius <= targets.Count - 1)
                            {
                                targets.RemoveRange(index - radius, radius * 2 + 1);
                            }
                            else
                            {
                                Console.WriteLine("Strike missed!");
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                            break;
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join("|", targets));

        }
    }
}
