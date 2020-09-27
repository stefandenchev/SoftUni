using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                var elements = input.Split(", ");
                var command = elements[0];
                var number = elements[1];

                if (command.Contains("IN"))
                {
                    parkingLot.Add(number);
                }
                
                else
                {
                    parkingLot.Remove(number);
                }

                input = Console.ReadLine();
            }

            if (parkingLot.Count > 0)
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }   
    }
}