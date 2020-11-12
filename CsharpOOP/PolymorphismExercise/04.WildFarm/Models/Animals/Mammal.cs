using _04.WildFarm.Models.Animals.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weigth, string livingRegion) : base(name, weigth)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}