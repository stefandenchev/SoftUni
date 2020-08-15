using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = String.Empty;
            bool hasChanged = false;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        hasChanged = true;
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        hasChanged = true;
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        hasChanged = true;
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        hasChanged = true;
                        break;

                    case "Contains":
                        if (numbers.Contains(int.Parse(command[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "PrintOdd":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 1)
                            {
                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        switch (command[1])
                        {
                            case "<":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] < int.Parse(command[2]))
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;
                            case ">":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] > int.Parse(command[2]))
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;
                            case "<=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] <= int.Parse(command[2]))
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;
                            case ">=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] >= int.Parse(command[2]))
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;
                        }
                        break;
                }
            }

            if (hasChanged)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }

        }
    }
}
