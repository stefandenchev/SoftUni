using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            data = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Present present)
        {
            if (Capacity > data.Count)
            {
                data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var toRemove = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(toRemove);
        }

        public Present GetHeaviestPresent()
        {
            Present heaviest = data.OrderByDescending(x => x.Weight).FirstOrDefault();
            return heaviest;
        }

        public Present GetPresent(string name)
        {
            var present = data.FirstOrDefault(x => x.Name == name);
            return present;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}