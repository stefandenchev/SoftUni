using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var elements = input.Split();
                if (elements[0].Contains("1"))
                {
                    int num = int.Parse(elements[1]);
                    stack.Push(num);
                }
                if (elements[0].Contains("2"))
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                if (elements[0].Contains("3"))
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                if (elements[0].Contains("4"))
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}