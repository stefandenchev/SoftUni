using System;
using System.Collections.Generic;

namespace _01.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int digit = int.Parse(Console.ReadLine());

            List<int> binarySequence = new List<int>();

            int count = 0;

            string binary = Convert.ToString(number, 2);

            while (number != 0)
            {
                int reminder = number % 2;
                if (reminder == digit)
                {
                    count++;

                }
                number /= 2;
            }
            
            //Console.WriteLine(binary);
            Console.WriteLine(count);
        }   
    }
}
