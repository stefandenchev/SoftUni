using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();
            string inputWords = File.ReadAllText("../../../words.txt");
            string[] words = inputWords.Split();
            words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            using var writer = new StreamWriter("../../../actualResult.txt");
            using var writer2 = new StreamWriter("../../../expectedResult.txt");

            using (var reader = new StreamReader("../../../text.txt"))
            {
                string currentSentence = reader.ReadLine();

                while (currentSentence != null)
                {
                    foreach (var word in words)
                    {
                        if (currentSentence.ToLower().Contains(word))
                        {

                            if (!dictionary.ContainsKey(word))
                            {
                                dictionary.Add(word, 0);
                                dictionary[word]++;
                            }
                            else
                            {
                                dictionary[word]++;
                            }
                        }
                    }

                    currentSentence = reader.ReadLine();
                }
                foreach (var word in dictionary)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
                foreach (var word in dictionary.OrderByDescending(x => x.Value))
                {
                    writer2.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}