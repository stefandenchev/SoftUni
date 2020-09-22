using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int greenDurationOriginal = greenDuration;
            int windowDuration = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsCount = 0;

            while (true)
            {
                int greenLight = greenDuration;
                int window = windowDuration;

                string car = Console.ReadLine();
                if (car == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{carsCount} total cars passed the crossroads.");
                    return;
                }

                if (car == "green")
                {
                    while (greenLight > 0 && cars.Count != 0)
                    {
                        string carInQueue = cars.Dequeue();
                        greenLight -= carInQueue.Count();
                        if (greenLight >= 0)
                        {
                            carsCount++;
                        }

                        else
                        {
                            window += greenLight;
                            if (window < 0)
                            {
                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                   $"{carInQueue} was hit at" +
                                   $" {carInQueue[carInQueue.Length + window]}.");
                                return;
                            }
                            carsCount++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }
            }


        }
    }
}