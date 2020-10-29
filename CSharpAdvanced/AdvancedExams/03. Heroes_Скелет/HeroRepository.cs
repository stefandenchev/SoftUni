using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        public HeroRepository()
        {
            data = new List<Hero>();
        }
        private List<Hero> data;
        public int Count => data.Count;

        public void Add(Hero hero)
        {
            data.Add(hero);
        }

        public void Remove(string name)
        {
            var toRemove = data.FirstOrDefault(x => x.Name == name);
            data.Remove(toRemove);
        }

        public Hero GetHeroWithHighestStrength()
        {
            int best = 0;
            Hero bestHero = null;
            foreach (var hero in data)
            {
                if (hero.Item.Strength > best)
                {
                    best = hero.Item.Strength;
                    bestHero = hero;
                }
            }

            return bestHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int best = 0;
            Hero bestHero = null;
            foreach (var hero in data)
            {
                if (hero.Item.Ability > best)
                {
                    best = hero.Item.Ability;
                    bestHero = hero;
                }
            }

            return bestHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int best = 0;
            Hero bestHero = null;
            foreach (var hero in data)
            {
                if (hero.Item.Intelligence > best)
                {
                    best = hero.Item.Intelligence;
                    bestHero = hero;
                }
            }

            return bestHero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in data)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}