using System;

namespace _01.BiscuitsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            double workerOutputPerDay = double.Parse(Console.ReadLine());
            int workerCount = int.Parse(Console.ReadLine());
            double competitorOutput = double.Parse(Console.ReadLine());

            double dailyOutput = workerOutputPerDay * workerCount;
            double originalValue = dailyOutput;
            double totalOutput = 0;

            for (int i = 1; i <= 30; i++)
            {
                dailyOutput = originalValue;
                if (i % 3 == 0)
                {
                    dailyOutput = Math.Floor(dailyOutput * 0.75);
                }
                totalOutput += dailyOutput;
            }

            Console.WriteLine($"You have produced {totalOutput:f0} biscuits for the past month.");

            if (totalOutput > competitorOutput)
            {
                double difference = totalOutput - competitorOutput;
                double percentage = difference / competitorOutput * 100;
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                double difference = competitorOutput - totalOutput;
                double percentage = difference / competitorOutput * 100;
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }

        }
    }
}