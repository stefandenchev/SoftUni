using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());

            int peopleCount = int.Parse(Console.ReadLine());

            int totalPerHour = firstEmployee + secondEmployee + thirdEmployee;

            int time = 0;
            int count = 0;

            while (peopleCount > 0)
            {
                if (count == 3)
                {
                    count = 0;
                    time++;
                    continue;
                }
                peopleCount -= totalPerHour;
                time++;
                count++;
            }
            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
