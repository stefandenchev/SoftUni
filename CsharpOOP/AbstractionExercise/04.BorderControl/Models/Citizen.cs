using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizen : IEntity, IAlive, IBuyer
    {
        private int food = 0;
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
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
            Food += 10;
        }
    }
}
