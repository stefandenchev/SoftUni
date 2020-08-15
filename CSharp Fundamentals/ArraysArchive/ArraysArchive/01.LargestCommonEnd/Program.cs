using System;
using System.Linq;

namespace _01.LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split().ToArray();
            string[] arr2 = Console.ReadLine().Split().ToArray();
            int counterLeft = 0;
            int counterRight = 0;

            for (int i = 0; i < arr1.Length && i < arr2.Length; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    counterLeft++;
                }
            }
            for (int i = 0; i < arr1.Length && i < arr2.Length; i++)
            {

                if (arr1[arr1.Length - 1 - i] == arr2[arr2.Length - 1 - i])
                {
                    counterRight++;
                }
            }
            Console.WriteLine(counterLeft > counterRight ? counterLeft : counterRight);
        }
    }
}