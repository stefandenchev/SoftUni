using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories.Common
{
    public static class GlobalConstants
    {
        public const string InvalidDoughMsg = "Invalid type of dough.";
        public const string InvalidAmountMsg = "Dough weight should be in the range [1..200].";
        public const string InvalidToppingMsg = "Cannot place {0} on top of your pizza.";
        public const string InvalidToppingAmountMsg = "{0} weight should be in the range [1..50].";
        public const string InvalidPizzaNameMsg = "Pizza name should be between 1 and 15 symbols.";
        public const string TooManyToppingsMsg = "Number of toppings should be in range [0..10].";

    }
}
