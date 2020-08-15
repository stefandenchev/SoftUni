using System;

namespace Demo5_forEach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            foreach (int number in arr)
            {
                Console.WriteLine(number);
            }

            string[] names = Console.ReadLine().Split();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
