using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(' ');
            int count = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(children);

            while (queue.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine("Removed " + queue.Dequeue()); 
                //PrintQueue(queue);
            }
            Console.WriteLine("Last is " + queue.Dequeue());
        }

        static void PrintQueue(Queue<string> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();
        }
    }
}