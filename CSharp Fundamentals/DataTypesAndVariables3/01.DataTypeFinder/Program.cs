using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int intValue;
            float floatValue;
            char charValue;
            bool booleanValue;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if(int.TryParse(input, out intValue))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if(float.TryParse(input, out floatValue))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out charValue))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out booleanValue))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }
        }
    }
}
