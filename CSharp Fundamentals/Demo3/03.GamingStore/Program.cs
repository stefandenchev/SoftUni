using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double begBudget = budget;
            double costs = 0;
            string input = Console.ReadLine();

            while (input != "Game Time")
            {
                double currentCosts = 0;
                switch (input)
                {
                    case "OutFall 4":
                        currentCosts += 39.99;
                        break;
                    case "CS: OG":
                        currentCosts += 15.99;
                        break;
                    case "Zplinter Zell":
                        currentCosts += 19.99;
                        break;
                    case "Honored 2":
                        currentCosts += 59.99;
                        break;
                    case "RoverWatch":
                        currentCosts += 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        currentCosts += 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        input = Console.ReadLine();
                        continue;
                }
                if (currentCosts > budget)
                {
                    Console.WriteLine("Too Expensive");
                    input = Console.ReadLine();
                    continue;
                }
                else if (currentCosts == budget)
                {
                    Console.WriteLine($"Bought {input}");
                    Console.WriteLine("Out of money!");
                    costs += currentCosts;
                    return;
                }
                else if (currentCosts < budget)
                {
                    Console.WriteLine($"Bought {input}");
                    input = Console.ReadLine();
                    budget -= currentCosts;
                    costs += currentCosts;
                }
            }
            Console.WriteLine($"Total spent: ${costs:f2}. Remaining: ${begBudget - costs:f2}");
        }
    }
}
