using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wins = 0;
            bool noEnergy = false;

            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                int distance = int.Parse(command);

                if (energy >= distance)
                {
                    energy -= distance;
                    wins++;
                    if (wins % 3 == 0)
                    {
                        energy += wins;
                    }
                }
                else
                {
                    noEnergy = true;
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    break;
                }

                command = Console.ReadLine();
            }

            if (!noEnergy)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}