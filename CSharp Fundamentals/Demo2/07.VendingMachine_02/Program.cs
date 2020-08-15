﻿using System;

namespace _07.VendingMachine_02
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalSum = 0;

            string command = Console.ReadLine();

            while (command != "Start")
            {
                double currentAmount = double.Parse(command);

                if (currentAmount != 0.1 && currentAmount != 0.2 && currentAmount != 0.5 && currentAmount != 1 && currentAmount != 2)
                {
                    Console.WriteLine($"Cannot accept {currentAmount}");
                }
                else
                {
                    totalSum += currentAmount;
                }
                command = Console.ReadLine();
            }
            string item = Console.ReadLine();

            while (item != "End")
            {
                double currentPrice = 0;
                switch (item)
                {
                    case "Nuts":
                        currentPrice = 2.0;
                        break;
                    case "Water":
                        currentPrice = 0.7;
                        break;
                    case "Crisps":
                        currentPrice = 1.5;
                        break;
                    case "Soda":
                        currentPrice = 0.8;
                        break;
                    case "Coke":
                        currentPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        item = Console.ReadLine();
                        continue;
                }

                if (totalSum >= currentPrice)
                {
                    totalSum -= currentPrice;
                    Console.WriteLine($"Purchased {item.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not eonugh money");
                }
                item = Console.ReadLine();

            }
            Console.WriteLine($"Change: {totalSum:F2}");
        }
    }
}