﻿using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;


        public Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return this.gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.gun = value;
            }
        }

        public bool IsAlive => Health > 0;

        public void TakeDamage(int points)
        {
            if (Armor >= points)
            {
                Armor -= points;
            }
            else
            {
                points -= Armor;

                Armor = 0;

                if (Health > points)
                {
                    Health -= points;
                }
                else
                {
                    Health = 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.GetType().Name}: {this.Username}")
                .AppendLine($"--Health: {Health}")
                .AppendLine($"--Armor: {Armor}")
                .AppendLine($"--Gun: {Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}