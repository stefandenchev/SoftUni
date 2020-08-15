using System;
using System.Linq;

namespace _09.KF_fkme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            string[] bestDna = null;
            int bestLength = -1;
            int bestSum = 0;

            int bestIndex = -1;

            int bestSequenceIndex = 1;
            int currentSequenceIndex = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Clone them!")
                {
                    break;
                }
                string[] currentDna = input.Split('!', StringSplitOptions.RemoveEmptyEntries);

                int currentLength = 0;
                int currentEndIndex = 0;
                int currentBestLength = 0;

                int currentBestSum = 0;


                for (int i = 0; i < currentDna.Length; i++)
                {
                    if (currentDna[i] == "1")
                    {
                        currentLength++;
                        if (currentLength > currentBestLength)
                        {
                            currentBestLength = currentLength;
                            currentEndIndex = i;
                        }
                    }
                    else
                    {
                        currentLength = 0;
                    }
               }

                
                // int sum = 0;


                /*for (int j = 0; j < currentDna.Length; j++)
                {
                    sum += int.Parse(currentDna[j]);
                }
                if (sum > currentBestSum)
                {
                    currentBestSum = sum;
                }
                if(currentBestSum > bestSum)
                {
                    bestSum = currentBestSum;
                }*/

                int currentDnaSum = currentDna.Select(int.Parse).Sum();

                int currentStartingIndex = currentEndIndex - currentBestLength + 1;

                bool isBestDna = false;


                currentSequenceIndex++;

                if (currentBestLength > bestLength)
                {
                    isBestDna = true;
                }
                else if (currentBestLength == bestLength)
                {
                    if (currentStartingIndex < bestIndex)
                    {
                        isBestDna = true;
                    }
                    else if (currentStartingIndex == bestIndex)
                    {
                        if (currentDnaSum > bestSum)
                        {
                            isBestDna = true;
                            //bestLength = bestSum;
                        }
                    }
                }


                if (isBestDna)
                {
                    bestSequenceIndex = currentSequenceIndex;
                    bestSum = currentBestSum;
                    bestDna = currentDna;
                    bestLength = currentBestLength;
                    bestIndex = currentStartingIndex;
                    bestSum = currentDnaSum;
                }


            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSum}.");
            Console.WriteLine(String.Join(" ", bestDna));
        }
    }
}
