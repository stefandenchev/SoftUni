using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenCount = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command = Console.ReadLine();
            int count = 0;

            while (command != "end")
            {
                if(command == "green")
                {
                    for (int i = 0; i < greenCount; i++)
                    {
                        if (cars.Count == 0) break;
                        count++;
                        Console.WriteLine(cars.Dequeue() + " passed!");
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(count + " cars passed the crossroads.");
        }
    }
}