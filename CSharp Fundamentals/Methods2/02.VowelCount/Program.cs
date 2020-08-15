using System;
using System.Linq;

namespace _02.VowelCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            PrintVowelCount(text);
        }

        static void PrintVowelCount(string text)
        {
            int counter = 0;
            char[] vowels = new char[] {'a', 'e', 'i', 'o', 'u'};

            for (int i = 0; i < text.Length; i++)
            {
                if (vowels.Contains(text[i]))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
