using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] maleNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] femaleNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> males = new Stack<int>(maleNums);
            Queue<int> females = new Queue<int>(femaleNums);

            int counter = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int male = males.Peek();
                int female = females.Peek();

                if (male > 0 && female > 0)
                {
                    if (male % 25 == 0 || female % 25 == 0)
                    {

                        if (male % 25 == 0)
                        {
                            if (males.Count > 1)
                            {
                                males.Pop();
                                males.Pop();
                            }
                            else
                            {
                                males.Pop();
                            }
                        }

                        if (female % 25 == 0)
                        {
                            if (females.Count > 1)
                            {
                                females.Dequeue();
                                females.Dequeue();
                            }
                            else
                            {
                                females.Dequeue();
                            }
                        }
                        continue;
                    }
                }
                if (male <= 0 || female <= 0)
                {

                    if (male <= 0)
                    {
                        males.Pop();
                    }
                    if (female <= 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (male == female)
                {
                    counter++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    male -= 2;
                    males.Pop();
                    males.Push(male);
                }

            }

            Console.WriteLine($"Matches: {counter}");
            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {String.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {String.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}