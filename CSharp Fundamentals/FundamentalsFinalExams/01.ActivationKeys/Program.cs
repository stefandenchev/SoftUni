using System;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Generate")
            {
                var elements = input.Split(">>>");
                if (input.Contains("Contains"))
                {
                    string substring = elements[1];
                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }

                }

                else if (input.Contains("Flip"))
                {
                    string type = elements[1];
                    int startIndex = int.Parse(elements[2]);
                    int endIndex = int.Parse(elements[3]);
                    var charArr = activationKey.ToCharArray();

                    if (type.Contains("Upper"))
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            charArr[i] = Char.ToUpper(charArr[i]);
                        }
                    }
                    else
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            charArr[i] = Char.ToLower(charArr[i]);
                        }
                    }

                    activationKey = new string(charArr);

                    Console.WriteLine(activationKey);
                }

                else if (input.Contains("Slice"))
                {
                    int startIndex = int.Parse(elements[1]);
                    int endIndex = int.Parse(elements[2]);

                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(activationKey);

                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}