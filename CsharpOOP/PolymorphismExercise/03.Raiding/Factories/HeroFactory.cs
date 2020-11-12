using _03.Raiding.Common;
using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Factories
{
    public class HeroFactory
    {
        public BaseHero Create(string name, string type)
        {
            BaseHero hero;

            if (type == "Druid")
            {
                hero = new Druid(name);
            }

            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }

            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }

            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidClassMsg);
            }

            return hero;
        }
    }
}
