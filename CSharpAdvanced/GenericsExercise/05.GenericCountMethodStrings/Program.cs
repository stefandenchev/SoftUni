using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> values = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                values.Add(input);
            }

            string value = Console.ReadLine();            

            Box<string> box = new Box<string>(values);

            int countOfGreaterValues = box.GetCountOfGreaterValues(value);

            Console.WriteLine(countOfGreaterValues);
        }
    }
}