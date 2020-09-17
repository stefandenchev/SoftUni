using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ").ToArray();
            Queue<string> queue = new Queue<string>(songs);
            var command = Console.ReadLine();

            while (queue.Count > 0)
            {
                if (command.Contains("Play"))
                {
                    queue.Dequeue();
                }

                else if (command.Contains("Add"))
                {
                    var songToAdd = command.Split("Add ", StringSplitOptions.RemoveEmptyEntries)[0];

                    if (queue.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(songToAdd);
                    }

                }

                else if (command.Contains("Show"))
                {
                    Console.WriteLine(String.Join(", ", queue));
                }

                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}