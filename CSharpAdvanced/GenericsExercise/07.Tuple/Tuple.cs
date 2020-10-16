using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    class Tuple<TFirst, TSecond>
    {
        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }

        public Tuple(TFirst firstItem, TSecond secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}