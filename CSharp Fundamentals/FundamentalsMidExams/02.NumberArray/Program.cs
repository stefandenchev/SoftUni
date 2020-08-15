using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.NumberArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                var elements = input.Split();

                string command = elements[0];

                switch (command)
                {
                    case "Switch":
                        var index = int.Parse(elements[1]);
                        if (index >= 0 && index <= nums.Count - 1)
                        {
                            nums[index] *= -1;
                        }
                        break;

                    case "Change":
                        var indexToChange = int.Parse(elements[1]);
                        var value = int.Parse(elements[2]);
                        if (indexToChange >= 0 && indexToChange <= nums.Count - 1)
                        {
                            nums.RemoveAt(indexToChange);
                            nums.Insert(indexToChange, value);
                        }
                        break;

                    case "Sum":
                        var type = elements[1];
                        int sum = 0;
                        switch (type)
                        {
                            case "Negative":
                                foreach (var num in nums.Where(x => x < 0))
                                {
                                    sum += num;
                                }
                                Console.WriteLine(sum);
                                break;

                            case "Positive":
                                foreach (var num in nums.Where(x => x > 0))
                                {
                                    sum += num;
                                }
                                Console.WriteLine(sum);
                                break;

                            case "All":
                                foreach (var num in nums)
                                {
                                    sum += num;
                                }
                                Console.WriteLine(sum);
                                break;
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            foreach (var num in nums.Where(x => x >= 0))
            {
                Console.Write(num + " ");
            }

        }
    }
}
