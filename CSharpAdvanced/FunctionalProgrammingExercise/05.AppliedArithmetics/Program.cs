using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();

            Func<int, int> addFunc = x => x + 1;
            Func<int, int> multiplyFunc = x => x * 2;
            Func<int, int> subtractFunc = x => x - 1;
            Action<List<int>> printFunc = x => Console.WriteLine(String.Join(" ", x));

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = numbers.Select(addFunc).ToList();
                        break;

                    case "multiply":
                        numbers = numbers.Select(multiplyFunc).ToList();
                        break;

                    case "subtract":
                        numbers = numbers.Select(subtractFunc).ToList();
                        break;

                    case "print":
                        printFunc(numbers);
                        break;
                }
                input = Console.ReadLine();
            }

        }
    }
}