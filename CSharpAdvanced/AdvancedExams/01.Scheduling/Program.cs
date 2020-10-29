using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasksInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var threadsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var taskToKill = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(tasksInput);
            Queue<int> threads = new Queue<int>(threadsInput);

            while (true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (taskToKill == currentTask)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");
                    break;
                }

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }

            }

            if (threads.Count > 0)
            {
                Console.WriteLine(String.Join(" ", threads));
            }

        }
    }
}