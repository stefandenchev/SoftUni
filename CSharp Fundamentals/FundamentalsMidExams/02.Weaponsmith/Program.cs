using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> particles = Console.ReadLine().Split("|").ToList();
            string input = Console.ReadLine();

            while (input != "Done")
            {
                var elements = input.Split();
                var command = elements[0];

                if (command == "Move")
                {
                    var direction = elements[1];
                    var index = int.Parse(elements[2]);
                    if (direction == "Left")
                    {
                        if (index >= 0 && index <= particles.Count - 1)
                        {
                            int tempIndex = index - 1;
                            if (tempIndex >= 0 && tempIndex <= particles.Count - 1)
                            {
                                var item = particles.ElementAt(index);
                                particles.RemoveAt(index);
                                particles.Insert(tempIndex, item);
                            }
                        }
                    }

                    else
                    {

                        if (index >= 0 && index <= particles.Count - 1)
                        {
                            int tempIndex = index + 1;
                            if (tempIndex >= 0 && tempIndex <= particles.Count - 1)
                            {
                                var item = particles.ElementAt(index);
                                particles.RemoveAt(index);
                                particles.Insert(tempIndex, item);
                            }
                        }

                    }
                }

                else
                {
                    var position = elements[1];
                    if (position == "Even")
                    {
                        for (int i = 0; i <= particles.Count - 1; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write(particles.ElementAt(i) + " ");
                            }
                        }
                        Console.WriteLine();
                    }

                    else
                    {
                        for (int i = 0; i <= particles.Count - 1; i++)
                        {
                            if (i % 2 == 1)
                            {
                                Console.Write(particles.ElementAt(i) + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {String.Join("", particles)}!");
        }
    }
}
