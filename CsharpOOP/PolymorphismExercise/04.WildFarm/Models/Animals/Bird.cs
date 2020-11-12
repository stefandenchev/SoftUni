using _04.WildFarm.Models.Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weigth, double wingSize) : base(name, weigth)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
