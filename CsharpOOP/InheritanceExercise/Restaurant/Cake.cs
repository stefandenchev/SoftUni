using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DefaultPrice = 5m;
        private const double DefaultCalories = 1000;
        private const double DefaultGrams = 250;

        public Cake(string name)
            : base(name, DefaultPrice, DefaultGrams, DefaultCalories)
        {
        }
    }
}
