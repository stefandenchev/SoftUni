using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02.TasksPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tasks = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            int completed = 0;
            int incomplete = 0;
            int dropped = 0;

            foreach (var task in tasks.Where(x => x > 0))
            {
                incomplete++;
            }

            foreach (var task in tasks.Where(x => x == 0))
            {
                completed++;
            }

            foreach (var task in tasks.Where(x => x < 0))
            {
                dropped++;
            }

            while (input != "End")
            {
                var elements = input.Split();
                var command = elements[0];

                switch (command)
                {
                    case "Complete":
                        var indexToComplete = int.Parse(elements[1]);
                        if (indexToComplete >= 0 && indexToComplete <= tasks.Count)
                        {
                            tasks[indexToComplete] = 0;
                            completed++;
                            incomplete--;
                        }
                        break;

                    case "Change":
                        var indexToChange = int.Parse(elements[1]);
                        var time = int.Parse(elements[2]);
                        if (indexToChange >= 0 && indexToChange <= tasks.Count)
                        {
                            tasks.RemoveAt(indexToChange);
                            tasks.Insert(indexToChange, time);
                        }
                        break;

                    case "Drop":
                        var indexToDrop = int.Parse(elements[1]);
                        if (indexToDrop >= 0 && indexToDrop <= tasks.Count)
                        {
                            tasks[indexToDrop] = -1;
                            dropped++;
                            incomplete--;
                        }
                        break;

                    case "Count":
                        var type = elements[1];
                        switch (type)
                        {
                            case "Completed":
                                Console.WriteLine(completed);
                                break;

                            case "Incomplete":
                                Console.WriteLine(incomplete);
                                break;

                            case "Dropped":
                                Console.WriteLine(dropped);
                                break;
                        }
                        break;

                }

                input = Console.ReadLine();
            }

            foreach (var task in tasks.Where(x => x > 0))
            {
                Console.Write(task + " ");
            }
        }
    }
}
