using _03.Raiding.Core.Contracts;
using _03.Raiding.Factories;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly HeroFactory heroFactory;
        List<BaseHero> heroes;

        public Engine()
        {
            heroFactory = new HeroFactory();
            heroes = new List<BaseHero>();
        }
        public void Run()
        {
            HeroFactory heroFactory = new HeroFactory();
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            while (n != counter)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = null;

                try
                {
                    hero = this.heroFactory.Create(name, type);
                    this.heroes.Add(hero);
                    counter++;
                }

                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int heroPower = heroes.Sum(h => h.Power);

            WonOrNot(bossPower, heroPower);
        }

        private static void WonOrNot(int bossPower, int heroPower)
        {
            if (bossPower > heroPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}