using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // power
            int m = int.Parse(Console.ReadLine()); // distance
            int y = int.Parse(Console.ReadLine()); // exhaustion factor

            int originalN = n;
            int counter = 0;

            while (n >= m)
            {
                if (n == originalN / 2)
                {
                    if (y > 0)
                    {
                        n /= y;
                        continue;
                    }
                }
                n -= m;
                counter++;
            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}