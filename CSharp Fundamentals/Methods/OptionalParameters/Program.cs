using System;

namespace OptionalParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbersBetween();
            PrintNumbersBetween(95, 105);        // it will take those, 0 - 100 are default if nothing is typed
                                                 // always left to right -> can't have optional end and set start  // unless use end: 5 e.g
        }
        static void PrintNumbersBetween(int start = 0, int end = 100)
        {
            for (int i = start; i < end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
