using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 50;


        private string type;
        private int grams;

        public Topping(string type, int grams)
        {
            Type = type;
            Grams = grams;
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                ValidateTopping(value);

                this.type = value;
            }
        }
        public int Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                ValidateToppingAmount(Type, value);

                this.grams = value;
            }
        }
        

        public double GetCalories()
        {
            double mod = 1.2;
            if (type.ToLower() == "veggies")
            {
                mod = 0.8;
            }
            if (type.ToLower() == "cheese")
            {
                mod = 1.1;
            }
            if (type.ToLower() == "sauce")
            {
                mod = 0.9;
            }

            return 2 * mod * Grams;
        }

        private static void ValidateTopping(string value)
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException(String.Format
                    (GlobalConstants.InvalidToppingMsg, value));
            }
        }

        private static void ValidateToppingAmount(string name, int value)
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException(String.Format
                    (GlobalConstants.InvalidToppingAmountMsg, name));
            }
        }

    }
}