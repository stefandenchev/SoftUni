using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(", ").Select(ParseNumber).ToArray();

            //PrintResults(array, GetCount, Sum);
            PrintResults(array, GetCount, x =>
            {
                int sum = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    sum += x[i];
                }
                return x.Sum();
            });
        }

        static int GetCount(int[] array)
        {
            return array.Length;
        }
        
        static int Sum(int[] array)
        {
            return array.Sum();
        }
        static void PrintResults(int[] array, Func<int[], int> count, Func<int[], int> sum)
        {
            Console.WriteLine(count(array));
            Console.WriteLine(sum(array));
        }
        static int ParseNumber(string number)
        {
            return int.Parse(number);
        }
    }
}