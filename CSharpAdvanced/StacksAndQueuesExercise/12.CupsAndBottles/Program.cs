using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(queueNums);

            var stackNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(stackNums);

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Peek(); 
                int currentBottle = bottles.Peek();

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    currentCup -= currentBottle;
                    bottles.Pop();
                    while (currentCup > 0)
                    {
                        currentBottle = bottles.Peek();
                        if (currentBottle >= currentCup)
                        {
                            wastedWater += currentBottle - currentCup;
                            currentCup = 0;
                            cups.Dequeue();
                            bottles.Pop();
                        }
                        else
                        {
                            currentCup -= currentBottle;
                            bottles.Pop();
                        }
                    }

                }
            }
            if (bottles.Count == 0 && cups.Count > 0)
            {
                Console.WriteLine($"Cups: {String.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}