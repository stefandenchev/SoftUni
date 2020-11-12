using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public virtual int Power { get; set; } = 100;

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}