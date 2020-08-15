using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hand1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> hand2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            int length = Math.Max(hand1.Count, hand2.Count);

            for (int i = 0; i < length; i++)
            {
                if (hand1.Count == 0 || hand2.Count == 0)
                {
                    break;
                }
                if (hand1[i] > hand2[i])
                {
                    hand1.Add(hand1[i]);
                    hand1.RemoveAt(i);
                    hand1.Add(hand2[i]);
                    hand2.RemoveAt(i);
                }
                else if (hand1[i] < hand2[i])
                {
                    hand2.Add(hand2[i]);
                    hand2.RemoveAt(i);
                    hand2.Add(hand1[i]);
                    hand1.RemoveAt(i);
                }
                else
                {
                    hand1.RemoveAt(i);
                    hand2.RemoveAt(i);
                }
                i--;
            }

            if (hand1.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {hand2.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {hand1.Sum()}");
            }

        }
    }
}
