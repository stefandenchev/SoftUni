using System;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string text = "";

            for (int i = 0; i < input; i++)
            {
                string currentDigit = Console.ReadLine();
                int mainDigit = int.Parse(currentDigit[0].ToString());

                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 0)
                {
                    text += " ";
                    continue;
                }

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                int offsetInSquare = currentDigit.Length;
                int totalOffset = offset + offsetInSquare - 1;
                char letter = (char)(97 + totalOffset);
                text += letter;

            }
            Console.WriteLine(text);
        }
    }
}
