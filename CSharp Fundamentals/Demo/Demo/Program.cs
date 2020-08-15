using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = 5.5334;
            int percentage = 55;
            Console.WriteLine("{0:F2}", grade);
            Console.WriteLine("{0:D6}", percentage);
        }
    }
}
