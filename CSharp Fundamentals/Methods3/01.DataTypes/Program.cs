using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataType = Console.ReadLine();
            var input = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int num = int.Parse(input);
                    DataTypeOperation(num);
                    break;
                case "real":
                    double num2 = double.Parse(input);
                    DataTypeOperation(num2);
                    break;
                case "string":
                    DataTypeOperation(input);
                    break;
            }
        }

        static void DataTypeOperation(int input)
        {
            int result = input * 2;
            Console.WriteLine(result);
        }
        static void DataTypeOperation(double input)
        {
            double result = input * 1.5;
            Console.WriteLine($"{result:f2}");
        }
        static void DataTypeOperation(string input)
        {
            Console.WriteLine($"${input}$");
        }

    }
}
