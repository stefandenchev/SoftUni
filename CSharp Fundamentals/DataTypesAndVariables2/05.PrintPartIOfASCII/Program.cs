using System;

namespace _05.PrintPartIOfASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                char a = (char)i;
                Console.Write(a + " ");
            }
        }
    }
}
