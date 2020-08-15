using System;

namespace _05.DecrpytingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());
            string code = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                letter += (char)(key);
                code += letter;
            }
            Console.WriteLine(code);
        }
    }
}
