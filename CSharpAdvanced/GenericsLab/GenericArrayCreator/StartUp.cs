using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        { 
            Console.WriteLine(String.Join(",", ArrayCreator.Create(10, "pesho")));
        }
    }
}
