using System;
using System.Linq;

namespace _01.EncryptSortPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            int names = int.Parse(Console.ReadLine());
            int[] finalNumbers = new int[names];

            for (int i = 0; i < names; i++)
            {
                int currentSum = 0;
                //var input = Console.ReadLine().Split("").ToArray();
                string input = Console.ReadLine();
                char[] letters = input.ToCharArray();

                for (int j = 0; j < letters.Length; j++)
                {
                    if (letters[j] == 'a' || letters[j] == 'o' || letters[j] == 'e' || letters[j] == 'u' || letters[j] == 'i'
                        || letters[j] == 'A' || letters[j] == 'O' || letters[j] == 'E' || letters[j] == 'U' || letters[j] == 'I')
                    {
                        currentSum += letters[j] * input.Length;
                    }
                    else
                    {
                        currentSum += letters[j] / input.Length;
                    }
                }
                finalNumbers[i] += currentSum;
            }
            Array.Sort(finalNumbers);
            foreach (var item in finalNumbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
