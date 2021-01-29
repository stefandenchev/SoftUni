using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private ICollection<Item> items;

        protected Bag(int capacity)
        {
            items = new List<Item>();
        }


        public virtual int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = 100;
            }
        }

        public int Load => this.items.Count * 5;

        public IReadOnlyCollection<Item> Items
            => (IReadOnlyCollection<Item>)this.items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item itemToFind = this.items.FirstOrDefault(x => x.GetType().Name == name);
            if (itemToFind == null)
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(itemToFind);
            return itemToFind;
        }
    }
}