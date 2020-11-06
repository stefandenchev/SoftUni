using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new Dictionary<int, Private>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                ISoldier soldier = null;
                var elements = input.Split();
                string soldierType = elements[0];
                int id = int.Parse(elements[1]);
                string firstName = elements[2];
                string lastName = elements[3];

                if (soldierType == typeof(Private).Name)
                {
                    decimal salary = decimal.Parse(elements[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (soldierType == typeof(Spy).Name)
                {
                    int codeNumber = int.Parse(elements[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else if (soldierType == typeof(LieutenantGeneral).Name)
                {
                    ICollection<Private> privates = new List<Private>();

                    decimal salary = decimal.Parse(elements[4]);

                    if (elements.Length >= 5)
                    {
                        for (var i = 5; i < elements.Length; i++)
                        {
                            var privateId = int.Parse(elements[i]);
                            var privateSoldier = soldiers[privateId];

                            privates.Add(privateSoldier);
                        }
                    }

                    //soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                // TODO create of soldier of type...

                //soldiers.Add(soldier);

            }

            //PrintResult(soldiers);
        }

        private static void PrintResult(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }


    }
}
