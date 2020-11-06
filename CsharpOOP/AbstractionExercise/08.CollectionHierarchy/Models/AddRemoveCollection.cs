using _08.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        List<string> list;
        public AddRemoveCollection()
        {
            list = new List<string>(100);
        }
        public int Add(string item)
        {
            list.Insert(0, item);
            return list.IndexOf(item);
        }

        public string Remove()
        {
            string item = this.list.Last();
            this.list.RemoveAt(this.list.Count - 1);
            return item;
        }
    }
}
