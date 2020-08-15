using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int totalPerHour = firstEmployee + secondEmployee + thirdEmployee;

            int time = 0;
            int count = 0;

            while (studentsCount > 0)
            {
                if (count == 3)
                {
                    count = 0;
                    time++;
                    continue;
                }
                studentsCount -= totalPerHour;
                time++;
                count++;
            }
            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}