using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            var bombCasings = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

            Queue<int> effects = new Queue<int>(bombEffects);
            Stack<int> casings = new Stack<int>(bombCasings);

            int daturaBomb = 40;
            int daturaCount = 0;
            int cherryBomb = 60;
            int cherryCount = 0;
            int smokeDecoyBomb = 120;
            int smokeCount = 0;

            bool full = false;
            bool bombMade = false;

            while (effects.Count > 0 && casings.Count > 0)
            {
                if (full)
                {
                    break;
                }

                bombMade = false;

                int currEff = effects.Peek();
                int currCas = casings.Peek();

                while (!bombMade)
                {
                    if (currEff + currCas == daturaBomb)
                    {
                        daturaCount++;
                        effects.Dequeue();
                        casings.Pop();
                        bombMade = true;
                    }

                    else if (currEff + currCas == cherryBomb)
                    {
                        cherryCount++;
                        effects.Dequeue();
                        casings.Pop();
                        bombMade = true;
                    }

                    else if (currEff + currCas == smokeDecoyBomb)
                    {
                        smokeCount++;
                        effects.Dequeue();
                        casings.Pop();
                        bombMade = true;
                    }

                    else
                    {
                        currCas -= 5;
                    }
                }

                if (daturaCount >= 3 && cherryCount >= 3 && smokeCount >= 3)
                {
                    full = true;
                }
            }

            if (full)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", effects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");
        }
    }
}