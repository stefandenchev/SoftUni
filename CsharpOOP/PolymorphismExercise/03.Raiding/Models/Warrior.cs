using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}