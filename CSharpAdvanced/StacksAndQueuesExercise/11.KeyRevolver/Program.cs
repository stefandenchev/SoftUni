using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            var stackNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(stackNums);

            var queueNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(queueNums);

            int value = int.Parse(Console.ReadLine());
            int bulletsUsed = 0;
            int barrelCount = 0;

            while (bullets.Any() && locks.Any())
            {
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                barrelCount++;
                if (barrelSize == barrelCount && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    barrelCount = 0;
                }
                bulletsUsed++;
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int bulletPriceTotal = bulletPrice * bulletsUsed;
                int potentialMoney = value - bulletPriceTotal;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${potentialMoney}");
            }
        }
    }
}