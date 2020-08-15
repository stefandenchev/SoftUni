using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());    // 5
            int[] field = new int[fieldSize];                 // 0 0 0 0 0 0 0 0 0 0
                                                              // 1 1 0 0 0 1 0 0 0 0

            string[] initialIndexes = Console.ReadLine().Split().ToArray();  // 0 1 5

            //Console.WriteLine(String.Join(" ", initialIndexes));

            for (int i = 0; i < fieldSize - 1; i++)
            {
                if (initialIndexes.Contains($"{i}"))
                {
                    field[i] = 1;
                }
            }

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "end")
                {
                    break;
                }

                string[] parts = input.Split(" ");

                int index = int.Parse(parts[0]);
                string direction = parts[1];
                int length = int.Parse(parts[2]);

                if (direction == "right" && length < 0)
                    direction = "left";

                else if (direction == "left" && length < 0)
                    direction = "right";

                if (index >= 0 && index < field.Length && field[index] != 0)
                {
                    int newIndex = index;
                    length = Math.Abs(length);

                    if (direction == "right")
                    {
                        while (newIndex < field.Length && field[newIndex] == 1)
                        {
                            newIndex += length;
                        }
                    }
                    else if (direction == "left")
                    {
                        while (newIndex >= 0 && field[newIndex] == 1)
                        {
                            newIndex -= length;
                        }
                    }
                    if (newIndex >= 0 && newIndex < field.Length)
                    {
                        field[newIndex] = 1;

                    }
                    field[index] = 0;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}