using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split());

            Queue<string> halls = new Queue<string>();
            int currentCapacity = capacity;
            List<int> reservations = new List<int>();

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                int people;
                if (int.TryParse(current, out people))
                {
                    string firstHall = null;
                    if (halls.Count > 0)
                    {
                        firstHall = halls.Peek();
                    }
                    currentCapacity -= people;
                    if (currentCapacity < 0)
                    {
                        if (firstHall != null)
                        {
                            Console.WriteLine($"{firstHall} -> {String.Join(", ", reservations)}");
                        }
                        if (halls.Count > 0)
                        {
                            halls.Dequeue();
                        }
                        reservations = new List<int>();
                        if (halls.Count > 0)
                        {
                            currentCapacity = capacity - people;
                            reservations.Add(people);
                        }
                        else
                        {
                            currentCapacity = capacity;
                        }
                    }
                    else
                    {
                        reservations.Add(people);
                    }
                }
                else
                {
                    halls.Enqueue(current);
                }
            }

        }
    }
}