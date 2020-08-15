using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());
            int lectureCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double bestTotalBonus = 0;
            int maxAttendances = 0;

            for (int i = 0; i < studentCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                if (attendances > maxAttendances)
                {
                    maxAttendances = attendances;
                    bestTotalBonus = (1.0 * attendances / lectureCount) * (5 + additionalBonus);
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(bestTotalBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}
