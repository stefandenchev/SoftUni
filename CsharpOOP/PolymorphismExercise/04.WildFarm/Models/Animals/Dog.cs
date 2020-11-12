using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weigth, string livingRegion) : base(name, weigth, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.4;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}