﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private const double OverallPerformanceMultiplier = 1.2;
        public SolidStateDrive(int id, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }
        public override double OverallPerformance =>
            base.OverallPerformance * OverallPerformanceMultiplier;
    }
}