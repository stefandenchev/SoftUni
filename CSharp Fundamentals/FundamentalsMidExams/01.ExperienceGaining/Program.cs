using System;

namespace _01.ExperienceGaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double expNeeded = double.Parse(Console.ReadLine());
            int maxBattles = int.Parse(Console.ReadLine());
            int battleCount = 0;

            for (int i = 1; i <= maxBattles; i++)
            {
                double currentExp = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    currentExp += currentExp * 0.15;
                }
                if (i % 5 == 0)
                {
                    currentExp -= currentExp * 0.1;
                }

                expNeeded -= currentExp;
                battleCount++;

                if (expNeeded <= 0)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
                    return;
                }
            }

            Console.WriteLine($"Player was not able to collect the needed experience, {expNeeded:f2} more needed.");
        }
    }
}
