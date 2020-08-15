using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighbourhood = Console.ReadLine().Split("@").Select(int.Parse).ToList();

            string command = Console.ReadLine();
            int index = 0;

            while (command != "Love!")
            {
                var elements = command.Split();
                int jumpForce = int.Parse(elements[1]);

                if (index + jumpForce < neighbourhood.Count)
                {
                    index += jumpForce;
                }
                else
                {
                    index = 0;
                }
                neighbourhood[index] -= 2;

                if (neighbourhood[index] == 0)
                {
                    Console.WriteLine($"Place {index} has Valentine's day.");
                }
                if (neighbourhood[index] < 0)
                {
                    Console.WriteLine($"Place {index} already had Valentine's day.");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {index}.");
            if (neighbourhood.All(x => x <= 0))
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int houseCount = 0;
                foreach (var house in neighbourhood.Where(x => x > 0))
                {
                    houseCount++;
                }
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}
