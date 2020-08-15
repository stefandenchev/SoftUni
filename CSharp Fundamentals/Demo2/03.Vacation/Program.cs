using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0;

            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price += number * 8.45;
                            break;
                        case "Saturday":
                            price += number * 9.80;
                            break;
                        case "Sunday":
                            price += number * 10.46;
                            break;
                    }
                    if (number >= 30)
                    {
                        price = price * 0.85;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            price += number * 10.90;
                            if (number >= 100)
                            {
                                price = price - 10 * 10.90;
                            }
                            break;
                        case "Saturday":
                            price += number * 15.60;
                            if (number >= 100)
                            {
                                price = price - 10 * 15.60;
                            }
                            break;
                        case "Sunday":
                            price += number * 16;
                            if (number >= 100)
                            {
                                price = price - 10 * 16;
                            }
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price += number * 15;
                            break;
                        case "Saturday":
                            price += number * 20;
                            break;
                        case "Sunday":
                            price += number * 22.50;
                            break;
                    }
                    if (number >= 10 && number <= 20)
                    {
                        price = price * 0.95;
                    }
                    break;
            }
            Console.WriteLine($"Total price: {price:F2}");
        }
    }
}
