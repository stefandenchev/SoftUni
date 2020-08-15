using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            int score = 0;

            string command = Console.ReadLine();

            while (command != "End")
            {
                int index = int.Parse(command);

                if (index >= 0 && index <= targets.Count - 1)
                {
                    if (targets[index] != -1)
                    {
                        int targetValue = targets[index];

                        targets[index] = -1;
                        score++;

                        for (int i = 0; i < targets.Count; i++)
                        {
                            if (targets[i] == -1)
                            {
                                continue;
                            }
                            if (targets[i] > targetValue)
                            {
                                targets[i] -= targetValue;
                            }
                            else
                            {
                                targets[i] += targetValue;
                            }
                        }

                    }
                }
                command = Console.ReadLine();
            }

            Console.Write($"Shot targets: {score} -> ");
            Console.Write(String.Join(" ", targets));
        }
    }
}
