using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower, double cubicCentimeters,
            int minHorsePower, int maxHorsePower)
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
            cubicCentimeters = 3000;
            minHorsePower = 250;
            maxHorsePower = 450;
        }
    }
}
