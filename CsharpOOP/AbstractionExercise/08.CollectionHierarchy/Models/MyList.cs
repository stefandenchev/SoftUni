using _08.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : IAddable, IRemovable
    {

        List<string> list;
        public MyList()
        {
            list = new List<string>(100);
        }

        public List<string> Used
        {
            get
            {
                return this.list as List<string>;
            }
        }

        public int Add(string item)
        {
            list.Insert(0, item);
            return list.IndexOf(item);
        }

        public string Remove()
        {
            string item = list.First();
            list.RemoveAt(0);
            return item;
        }
    }
}
