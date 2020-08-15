using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> startingDrumSet = new List<int>();

            for (int i = 0; i < drumSet.Count; i++)
            {
                startingDrumSet.Add(drumSet[i]);
            }

            string command = Console.ReadLine();

            while (command != "Hit it again, Gabsy!")
            {
                //double price = 0;
                int damage = int.Parse(command);
                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= damage;
                    if (drumSet[i] <= 0)
                    {
                        int price = startingDrumSet[i] * 3;
                        if (price <= savings)
                        {
                            drumSet[i] = startingDrumSet[i];
                            savings -= price;
                        }
                        else
                        {
                            drumSet.RemoveAt(i);
                            startingDrumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}