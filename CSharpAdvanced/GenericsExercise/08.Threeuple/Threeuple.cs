using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        public TFirst FirstItem { get; set; }
        public TSecond SecondItem { get; set; }
        public TThird ThirdItem { get; set; }

        public Threeuple(TFirst firstItem, TSecond secondItem, TThird thirdItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
            ThirdItem = thirdItem;
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
