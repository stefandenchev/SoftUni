using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());
            int inputInNumber = input - '0';
            
           // 17 - 42 A
           // 49 - 74 a
            
            if(inputInNumber >= 17 && inputInNumber <= 42)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
