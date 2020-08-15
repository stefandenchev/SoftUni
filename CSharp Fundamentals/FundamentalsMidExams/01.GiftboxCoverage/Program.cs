using System;

namespace _01.GiftboxCoverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int sheetsNumber = int.Parse(Console.ReadLine());
            double sheetSize = double.Parse(Console.ReadLine());

            double originalSheetSize = sheetSize;

            double boxArea = sideSize * sideSize * 6;
            double coverableArea = 0;

            for (int i = 1; i <= sheetsNumber; i++)
            {
                sheetSize = originalSheetSize;
                if (i % 3 == 0)
                {
                    sheetSize *= 0.25;
                }
                coverableArea += sheetSize;
            }

            double percentage = coverableArea / boxArea * 100;
            Console.WriteLine($"You can cover {percentage:f2}% of the box.");

        }
    }
}
