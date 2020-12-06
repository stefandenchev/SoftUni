using System;

namespace _03.Generating01Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var vector = new int[n];

            GenerateVector(vector, 0);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }
            for (int number = 0; number <= 1; number++)
            {
                vector[index] = number;
                GenerateVector(vector, index + 1);
            }
        }
    }
}