using System;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            while (true)
            {
                line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string reversed = "";
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    reversed += line[i];
                }
                Console.WriteLine($"{line} = {reversed}");
            }

        }
    }
}