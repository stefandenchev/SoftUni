using System;

namespace _01.BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double startingDailyPlunder = dailyPlunder;
            double actualPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                dailyPlunder = startingDailyPlunder;
                if (i % 3 == 0)
                {
                    dailyPlunder *= 1.5;
                }
                actualPlunder += dailyPlunder;
                if (i % 5 == 0)
                {
                    actualPlunder -= actualPlunder * 0.3;
                }
            }

            if (actualPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {actualPlunder:f2} plunder gained.");
            }
            else
            {
                double percentage = actualPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}
