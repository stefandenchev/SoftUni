using System;

namespace _12.EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            while (true)
            {
                number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    break;
                }
                Console.WriteLine("Please write an even number.");
            }
            Console.WriteLine($"The number is: {Math.Abs(number)}");
        }
    }
}
