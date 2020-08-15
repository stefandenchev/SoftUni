using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            FindMiddleCharacters(text);
        }

        static void FindMiddleCharacters(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text.Length % 2 == 1)
                {
                    Console.WriteLine(text[text.Length / 2]);
                    break;
                }
                else
                {
                    Console.Write(text[text.Length / 2 - 1]);
                    Console.Write(text[text.Length / 2]);
                    break;
                }
            }
        }
    }
}
