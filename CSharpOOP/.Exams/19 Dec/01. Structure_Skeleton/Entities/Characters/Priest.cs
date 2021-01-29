using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double HP = 50;
        private const double AR = 25;
        private const double AP = 40;
        //private Backpack backpack = new Backpack();
        public Priest(string name) : base(name, HP, AR, AP, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
