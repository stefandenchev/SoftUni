using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weigth, string livingRegion, string breed) : base(name, weigth, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}," +
                $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}