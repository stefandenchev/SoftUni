﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }

    }
}
