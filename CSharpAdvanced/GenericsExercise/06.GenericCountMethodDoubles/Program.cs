using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> values = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                values.Add(input);
            }

            double value = double.Parse(Console.ReadLine());

            Box<double> box = new Box<double>(values);

            int countOfGreaterValues = box.GetCountOfGreaterValues(value);

            Console.WriteLine(countOfGreaterValues);
        }
    }
}