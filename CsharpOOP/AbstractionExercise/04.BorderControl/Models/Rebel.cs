using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Rebel : IBuyer
    {
        private int food = 0;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food
        {
            get
            {
                return this.food;
            }
            set
            {
                food = value;
            }
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
