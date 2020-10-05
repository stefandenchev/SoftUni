using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> printNames = x => Console.WriteLine(String.Join(Environment.NewLine, x));
            printNames(names);
        }
    }
}