using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaInput = Console.ReadLine();

            try
            {
                while (true)
                {
                    var pizzaArgs = pizzaInput.Split();
                    string name = pizzaArgs[1];

                    string doughInput = Console.ReadLine();
                    var doughArgs = doughInput.Split();
                    var flour = doughArgs[1];
                    var tech = doughArgs[2];
                    var grams = int.Parse(doughArgs[3]);

                    Dough dough = new Dough(flour, tech, grams);
                    Pizza pizza = new Pizza(name, dough);

                    string toppingsInput = Console.ReadLine();
                    while (true)
                    {
                        var toppingsArgs = toppingsInput.Split();
                        var type = toppingsArgs[1];
                        var toppingGrams = int.Parse(toppingsArgs[2]);

                        Topping topping = new Topping(type, toppingGrams);
                        pizza.AddTopping(topping);

                        toppingsInput = Console.ReadLine();
                        if (toppingsInput == "END")
                        {
                            Console.WriteLine(pizza);
                            return;
                        }
                    }
                }
            }

            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}