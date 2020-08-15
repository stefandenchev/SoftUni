using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            bool doneMoney = false;
            bool doneFood = false;

            while (!doneMoney)
            {
                var input = Console.ReadLine();
                if (input == "Start")
                {
                    doneMoney = true;
                    break;
                }
                else
                {
                    double inputMoney = double.Parse(input);
                    if (inputMoney == 0.1 || inputMoney == 0.2 || inputMoney == 0.5 || inputMoney == 1 || inputMoney == 2)
                    {
                        sum += inputMoney;
                    }
                    else
                    {
                        Console.WriteLine($"Cannot accept {inputMoney}");
                        continue;
                    }
                }
            }

            while (!doneFood)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    doneFood = true;
                    break;
                }
                else
                {
                    switch (input)
                    {
                        case "Nuts":
                            if (sum >= 2.0)
                            {
                                sum -= 2.0;
                                Console.WriteLine($"Purchased nuts");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;

                        case "Water":
                            if (sum >= 0.7)
                            {
                                sum -= 0.7;
                                Console.WriteLine($"Purchased water");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;

                        case "Crisps":
                            if (sum >= 1.5)
                            {
                                sum -= 1.5;
                                Console.WriteLine($"Purchased crisps");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;

                        case "Soda":
                            if (sum >= 0.8)
                            {
                                sum -= 0.8;
                                Console.WriteLine($"Purchased soda");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;

                        case "Coke":
                            if (sum >= 1.0)
                            {
                                sum -= 1.0;
                                Console.WriteLine($"Purchased coke");
                            }
                            else
                            {
                                Console.WriteLine("Sorry, not enough money");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid product");
                            break;
                    }
                }
            }
            Console.WriteLine($"Change: {sum:F2}");

        }
    }
}