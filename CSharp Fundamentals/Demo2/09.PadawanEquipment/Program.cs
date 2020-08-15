using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());
            double saberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double saberPriceTotal = saberPrice * (Math.Ceiling(studentCount * 1.1));
            double robePriceTotal = robePrice * studentCount;
            double beltPriceTotal = beltPrice * studentCount;

            for (int i = studentCount; i > 0; i--)
            {
                if (i % 6 == 0)
                {
                    beltPriceTotal -= beltPrice;
                }
            }

            double costs = saberPriceTotal + robePriceTotal + beltPriceTotal;

            if (costs > money)
            {
                Console.WriteLine($"Ivan Cho will need {costs - money:f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {costs:f2}lv.");
            }
        }
    }
}
