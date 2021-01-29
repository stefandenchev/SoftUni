using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            BaseHealth = health;
            Armor = armor;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
            }
        }
        public double BaseHealth
        {
            get
            {
                return this.baseHealth;
            }
            set
            {
                this.baseHealth = value;
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                this.armor = value;
            }
        }

        public double BaseArmor
        {
            get
            {
                return this.baseArmor;
            }
            set
            {
                this.baseArmor = value;
            }
        }

        public double AbilityPoints
        {
            get
            {
                return this.abilityPoints;
            }
            set
            {
                this.abilityPoints = value;
            }
        }
        public Bag Bag
        {
            get
            {
                return this.bag;
            }
            set
            {
                this.bag = value;
            }
        }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor < hitPoints)
                {
                    double remHit = hitPoints - this.Armor;
                    this.Armor = 0;
                    if (this.Health < remHit)
                    {
                        this.Health = 0;
                        this.IsAlive = false;
                    }
                    else
                    {
                        this.Health -= remHit;
                    }
                }
                else
                {
                    this.Armor -= hitPoints;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}