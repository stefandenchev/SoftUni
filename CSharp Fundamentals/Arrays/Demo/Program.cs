using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "5 3 kuche kotka 2 1";
            string[] split = input.Split();
            int[] numbers = new int[split.Length];

            for (int i = 0; i < split.Length; i++)
            {
                Console.WriteLine(split[i]);
            }

            string input2 = Console.ReadLine();
            string[] split2 = input2.Split(new char[] { ',', ' ', '!', '?' },   // ---> // new string [] {"yyy"}, 
                StringSplitOptions.RemoveEmptyEntries);

            // input.Split(',', ' '); <--- easier

            for (int i = 0; i <  split2.Length;  i++)
            {
                Console.WriteLine($"arr[{i}]={split2[i]}");
            }

            /*int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(array[1]);
            Console.WriteLine(array[2]);
            Console.WriteLine(array[0]);
            Console.WriteLine(array[3]);*/
        }
    }
}
