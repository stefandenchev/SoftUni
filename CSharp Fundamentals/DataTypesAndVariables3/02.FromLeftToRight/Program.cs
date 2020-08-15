using System;

namespace _02.FromLeftToRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                string leftNum = string.Empty;
                string rightNum = string.Empty;
                long biggerNum = 0;
                long numberSum = 0;
                int counter = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    counter++;
                    char symbol = input[j];

                    if (symbol == ' ')
                    {
                        break;
                    }
                    leftNum += symbol;
                }

                for (int j = counter; j < input.Length; j++)
                {
                    char symbol = input[j];
                    rightNum += symbol;
                }

                biggerNum = Math.Max(Convert.ToInt64(leftNum), Convert.ToInt64(rightNum));

                while (Math.Abs(biggerNum) > 0)
                {
                    numberSum += Math.Abs(biggerNum) % 10;
                    biggerNum = Math.Abs(biggerNum) / 10;
                }
                Console.WriteLine(numberSum);
            }
        }
    }
}
