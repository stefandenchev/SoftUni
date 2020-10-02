using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = CountOfLetters(line);
                int marksCount = CountOfPunctuationMarks(line);

                result[i] = $"Line {i + 1}: {lines[i]} ({lettersCount})({marksCount})";
            }

            File.WriteAllLines("../../../outpix.txt", result);
        }

        static int CountOfLetters(string line)
        {
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currSym = line[i];
                if (Char.IsLetter(currSym))
                {
                    counter++;
                }
            }
            return counter;
        }

        static int CountOfPunctuationMarks(string line)
        {
            char[] marks = { '-', ',', '.', '!', '?', '\'', ':', ';' };
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currSym = line[i];
                if (marks.Contains(currSym))
                {
                    counter++;
                }
            }
            return counter;
        }

    }
}