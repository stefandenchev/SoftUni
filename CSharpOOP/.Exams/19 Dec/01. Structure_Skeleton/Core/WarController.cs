using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        ICollection<Character> party;
        Stack<Item> pool;

        public WarController()
        {
            this.party = new List<Character>();
            this.pool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character charToAdd = null;
            var type = args[0];
            var name = args[1];

            if (type == "Warrior")
            {
                charToAdd = new Warrior(name);
            }
            else if (type == "Priest")
            {
                charToAdd = new Priest(name);
            }
            else
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.InvalidCharacterType, type));
            }

            this.party.Add(charToAdd);
            return String.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            Item itemToAdd = null;
            var type = args[0];

            if (type == "HealthPotion")
            {
                itemToAdd = new HealthPotion();
            }
            else if (type == "FirePotion")
            {
                itemToAdd = new FirePotion();
            }
            else
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.InvalidItem, type));
            }

            this.pool.Push(itemToAdd);
            return String.Format(SuccessMessages.AddItemToPool, type);

        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            else if (this.pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var itemToTake = this.pool.Peek();
            character.Bag.AddItem(this.pool.Pop());
            return String.Format(SuccessMessages.PickUpItem, characterName, itemToTake.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            var charName = args[0];
            var itemName = args[1];
            Character character = this.party.FirstOrDefault(x => x.Name == charName);
            Item item = character.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, charName));
            }

            character.Bag.GetItem(itemName);

            character.UseItem(item);
            return String.Format(SuccessMessages.UsedItem, charName, itemName);
        }

        public string GetStats()
        {
            var sortedParty = this.party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);
            StringBuilder sb = new StringBuilder();
            foreach (var ch in sortedParty)
            {
                sb.AppendLine($"{ch.Name} - HP: {ch.Health}/{ch.BaseHealth}, AP: {ch.Armor}/{ch.BaseArmor}, Status: {(ch.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            Character attacker = this.party.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = this.party.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (receiver == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            if (attacker.GetType().Name == "Priest")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attackerName));
            }
            if (!attacker.IsAlive || !receiver.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            attacker.EnsureAlive();
            receiver.EnsureAlive();

            var realAttacker = (IAttacker)attacker;
            realAttacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points!" +
                $" {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and" +
                $" {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            Character healer = this.party.FirstOrDefault(x => x.Name == healerName);
            Character receiver = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healer));
            }
            if (receiver == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiver));
            }
            if (healer.GetType().Name == "Warrior")
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            healer.EnsureAlive();
            receiver.EnsureAlive();

            var realHealer = (IHealer)healer;
            realHealer.Heal(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has" +
                $" {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }
    }
}
