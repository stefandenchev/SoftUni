using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    public class Box<T>
    {
        public List<T> Values { get; set; } = new List<T>();

        public Box(List<T> value)
        {
            Values = value;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T tempVar = Values[firstIndex];
            Values[firstIndex] = Values[secondIndex];
            Values[secondIndex] = tempVar;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var value in Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}