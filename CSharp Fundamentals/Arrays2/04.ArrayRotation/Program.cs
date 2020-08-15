using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            // 32 61 21 51 47

            for (int i = 0; i < n; i++)
            {
                int firstElement = array[0]; // 32
                int[] temp = new int[array.Length]; // 0 0 0 0 0

                for (int j = 1; j < array.Length; j++)
                {
                    temp[j - 1] = array[j];
                }

                temp[temp.Length - 1] = firstElement;
                array = temp;
            }
            Console.WriteLine(String.Join(" ", array));
        }
    }
}
