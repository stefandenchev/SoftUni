using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);
            string command = Console.ReadLine().ToLower();
            while (command != "end")
            {
                var splitted = command.Split(' ');
                if (splitted[0] == "add")
                {
                    stack.Push(int.Parse(splitted[1]));
                    stack.Push(int.Parse(splitted[2]));
                }
                else if (splitted[0] == "remove")
                {
                    int count = int.Parse(splitted[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            int sum = 0;
            while(stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}