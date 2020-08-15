using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double price = double.Parse(Console.ReadLine());
            CalculateOrderPrice(product, price);
        }

        static void CalculateOrderPrice(string product, double price)
        {
            double totalPrice = 0;
            switch (product)
            {
                case "coffee":
                    totalPrice = price * 1.50;
                    break;
                case "water":
                    totalPrice = price * 1.00;
                    break;
                case "coke":
                    totalPrice = price * 1.40;
                    break;
                case "snacks":
                    totalPrice = price * 2.00;
                    break;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
