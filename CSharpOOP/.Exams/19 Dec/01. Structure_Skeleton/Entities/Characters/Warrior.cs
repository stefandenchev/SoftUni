using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double HP = 100;
        private const double AR = 50;
        private const double AP = 40;
        //private Satchel satchel = new Satchel();
        public Warrior(string name) : base(name, HP, AR, AP, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Equals(character))
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
