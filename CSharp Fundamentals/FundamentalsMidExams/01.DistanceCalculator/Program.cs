using System;

namespace _01.DistanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            double stepLength = double.Parse(Console.ReadLine());
            double originalStepLenght = stepLength;
            double distanceNeeded = double.Parse(Console.ReadLine());

            double distance = 0;

            for (int i = 1; i <= steps; i++)
            {
                stepLength = originalStepLenght;
                if (i % 5 == 0)
                {
                    stepLength *= 0.7;
                }
                distance += stepLength;
            }
            double percentage = distance / distanceNeeded;

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}