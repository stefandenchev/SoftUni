using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int totalYield = 0;
            int days = 0;
            bool exhausted = false;

            while (true)
            {
                if (yield < 100)
                {
                    exhausted = true;
                }
                else
                {
                    totalYield += yield;
                    yield -= 10;
                    days++;
                    totalYield -= 26;
                }

                if (exhausted)
                {
                    if (totalYield >= 26)
                    {
                        totalYield -= 26;
                        break;
                    }
                    else
                    {
                        totalYield = 0;
                        break;
                    }
                }
            }
            Console.WriteLine(days);
            Console.WriteLine(totalYield);
        }
    }
}
