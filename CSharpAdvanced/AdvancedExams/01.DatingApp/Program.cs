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

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currentMale = males.Peek();
                int currentFemale = females.Peek();

                if (currentMale <= 0)
                {
                    while (currentMale <= 0)
                    {
                        males.Pop();
                        currentMale = males.Peek();
                    }
                }

                if (currentFemale <= 0)
                {
                    while (currentMale <= 0)
                    {
                        females.Dequeue();
                        currentFemale = females.Peek();
                    }
                    
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Count > 0)
                    {
                        males.Pop();
                    }
                    else
                    {
                        break;
                    }
                    if (males.Count > 0)
                    {
                        currentMale = males.Peek();
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                    if (females.Count > 0)
                    {
                        currentFemale = females.Peek();
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentMale == currentFemale)
                {
                    matches++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {

                    females.Dequeue();
                    currentMale -= 2;
                    males.Pop();
                    males.Push(currentMale);
                }

            }

            Console.WriteLine($"Matches: {matches}");
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