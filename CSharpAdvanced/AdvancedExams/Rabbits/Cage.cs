using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    class Cage
    {
        List<Rabbit> data;
        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Rabbit>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Rabbit rabbit)
        {
            if (Capacity > data.Count)
            {
                data.Add(rabbit);
            }
        }

        public void RemoveRabbit(string name)
        {
            Rabbit rabbit = data.FirstOrDefault(x => x.Name == name);
            Console.WriteLine(data.Remove(rabbit)); // either this or cw in StartUp
        }

        public void RemoveSpecies(string species)
        {
            foreach (Rabbit rabbit in data.Where(x => x.Species == species).ToList())
            {
                data.Remove(rabbit);
            }
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = data.Where(x => x.Name == name).FirstOrDefault();
            rabbit.Available = false;
            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> sold = new List<Rabbit>();
            foreach (Rabbit rabbit in data.Where(x => x.Species == species).ToList())
            {
                rabbit.Available = false;
                sold.Add(rabbit);
            }
            return sold.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (Rabbit rabbit in data.Where(x => x.Available == true))
            {
                sb.AppendLine(rabbit.ToString());
            }
            return sb.ToString();
        }
    }
}
