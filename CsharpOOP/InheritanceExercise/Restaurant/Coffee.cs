using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DefaultMilliliters = 50;
        private const decimal DefaultPrice = 3.50m;

        public double Caffeine {get; set;}
        public Coffee(string name, double caffeine) : base(name, DefaultPrice, DefaultMilliliters)
        {
            Caffeine = caffeine;
        }
    }
}