using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
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

        public int GetCountOfGreaterValues(T value)
        {
            int counter = 0;

            foreach (T currentValue in Values)
            {
                if (value.CompareTo(currentValue) < 0)
                {
                    counter++;
                }
            }

            return counter;
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