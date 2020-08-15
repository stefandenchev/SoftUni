using System;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal price = decimal.Parse(Console.ReadLine());
            decimal moneyTotal = 0;
            decimal income = price / 4;
            int months = int.Parse(Console.ReadLine());

            for (int i = 1; i <= months; i++)
            {
                if (i % 2 == 1 && i != 1)
                {
                    moneyTotal -= moneyTotal * 0.16m;
                }
                if (i % 4 == 0)
                {
                    moneyTotal += moneyTotal * 0.25m;
                }
                moneyTotal += income;
            }

            decimal money = Math.Abs(moneyTotal - price);
            if (moneyTotal >= price)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {money:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {money:f2}lv. more.");
            }

        }
    }
}