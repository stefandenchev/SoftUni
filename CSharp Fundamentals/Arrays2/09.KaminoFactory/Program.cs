using System;
using System.Linq;


namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int index = 0;
            int bestIndex = 1;

            int length = 1;
            int bestLength = 0;

            int start = 0;
            int bestStart = 0;

            int sum = 0;
            int bestSum = 0;

            int[] bestArray = new int[dnaLength];

            while (true)
            {
                if (input == "Clone them!")
                {
                    break;
                }
                sum = 0;
                string[] split = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
                int[] array = split.Select(int.Parse).ToArray();
                index++;

                for (int j = 0; j < array.Length; j++)
                {
                    sum += array[j];
                }
                if (sum > bestSum)
                {
                    bestSum = sum;
                }

                for (int i = 1; i < array.Length; i++)
                {
                    if (i == 1)
                    {
                        start = i;
                    }
                    if (array[i] != 1)
                    {
                        continue;
                    }

                    else
                    {

                        if (array[i] == array[i - 1])
                        {
                            length++;
                        }
                        else
                        {
                            length = 1;
                            start = i;
                        }

                        if (length >= bestLength)
                        {
                            if (length > bestLength)
                            {
                                bestLength = length;
                                bestStart = start;
                                bestArray = array;
                                bestIndex = index;
                                continue;
                            }
                            if (length == bestLength && start <= bestStart)
                            {
                                if (start < bestStart)
                                {
                                    bestArray = array;
                                    bestIndex = index;
                                    continue;
                                }

                                if (length == bestLength && start == bestStart) // && sum == bestSum
                                {
                                    if (sum < bestSum)
                                    {
                                        bestLength = bestSum;
                                    }
                                }
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            if (length == bestLength && start == bestStart) // && sum == bestSum
            {
                for (int j = 0; j < bestArray.Length; j++)
                {
                    sum += bestArray[j];
                }
                if (sum > bestLength)
                {
                    m = sum;
                }
                /*if (sum < bestSum)
                {
                    maxLength = bestSum;
                }*/
            }
            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestLength}.");
            Console.WriteLine(String.Join(" ", bestArray));
        }
    }
}

/*int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

int maxLength = 0;
int length = 1;

int start = 0;
int bestStart = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    length++;
                }
                else
                {
                    length = 1;
                    start = i;
                }

                if (length > maxLength)
                {
                    maxLength = length;
                    bestStart = start;
                }
            }
            for (int i = bestStart; i<bestStart + maxLength; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}*/
/*
                for (int i = 0; i<length; i++)
                {
                    int[] tempSequence = new int[length];
                    for (int j = i + 1; j<length; j++)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            if (tempSequence[0] == 0)
                            {
                                tempSequence[0] = numbers[i];
                                tempSequence[1] = numbers[i];
                            }
                            else
                            {
                                tempSequence[i + 2] = numbers[i];
                            }
                        }
                        else
                        {
                            break;
                        }
                    }*/
