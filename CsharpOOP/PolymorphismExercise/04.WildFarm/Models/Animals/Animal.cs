using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Contracts
{
    public abstract class Animal
        : IAnimal, IFeedable, ISoundProducible
    {

        private const string INV_FOOD_TYPE = "{0} does not eat {1}!";
        protected Animal(string name, double weigth)
        {
            Name = name;
            Weight = weigth;
        }
        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PreferredFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(
                    String.Format(INV_FOOD_TYPE, this.GetType().Name, food.GetType().Name));
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightMultiplier;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
