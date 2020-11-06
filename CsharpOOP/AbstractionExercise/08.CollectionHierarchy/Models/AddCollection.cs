using _08.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    class AddCollection : IAddable
    {
        List<string> list;
        public AddCollection()
        {
            this.list = new List<string>();
        }
        public int Add(string item)
        {
            this.list.Add(item);
            return this.list.Count - 1;
        }
    }
}
