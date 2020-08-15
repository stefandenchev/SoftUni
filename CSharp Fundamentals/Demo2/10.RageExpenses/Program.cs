using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double kbPrice = double.Parse(Console.ReadLine());
            double disPrice = double.Parse(Console.ReadLine());

            double expenses = 0;

            for (int i = 1; i <= gamesLost; i++)
            {
                if(i % 2 == 0)
                {
                    expenses += headsetPrice;
                }
                if(i % 3 == 0)
                {
                    expenses += mousePrice;
                }
                if(i % 6 == 0)
                {
                    expenses += kbPrice;
                }
                if(i % 12 == 0)
                {
                    expenses += disPrice;
                }
            }
            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}