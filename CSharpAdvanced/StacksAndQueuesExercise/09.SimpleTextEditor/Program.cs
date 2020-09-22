using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> updates = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            updates.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split();
                string command = elements[0];

                switch (command)
                {
                    case "1":
                        string someString = elements[1];
                        sb.Append(someString);
                        updates.Push(sb.ToString());
                        break;

                    case "2":
                        sb.Remove(sb.Length - int.Parse(elements[1]), int.Parse(elements[1]));
                        updates.Push(sb.ToString());
                        break;

                    case "3":
                        int index = int.Parse(elements[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;

                    case "4":
                        updates.Pop();
                        sb = new StringBuilder();
                        sb.Append(updates.Peek());
                        break;
                }
            }
        }
    }
}