using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                ValidatePizzaName(value);

                this.name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; set; }


        public void AddTopping(Topping topping)
        {
            if (toppings.Count < 10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException(GlobalConstants.TooManyToppingsMsg);
            }
        }


        public double GetCalories()
        {
            double calories = 0;
            foreach (Topping topping in toppings)
            {
                calories += topping.GetCalories();
            }

            return calories + Dough.GetCalories();
        }

        private static void ValidatePizzaName(string value)
        {
            if (String.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException(GlobalConstants.InvalidPizzaNameMsg);
            }
        }

        public override string ToString()
        {
            return $"{Name} - {this.GetCalories():f2} Calories.";
        }
    }


}
