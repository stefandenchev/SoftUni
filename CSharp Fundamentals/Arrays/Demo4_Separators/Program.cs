using System;

namespace Demo4_Separators
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[5] { 1, 3, 2, 5, 7 };
            Console.WriteLine(String.Join(", ", nums));
        }
    }
}
