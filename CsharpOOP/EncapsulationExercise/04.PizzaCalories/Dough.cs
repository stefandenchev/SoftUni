using _04.PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int MIN_AMOUNT = 0;
        private const int MAX_AMOUNT = 200;

        private string flourType;
        private string bakingTechnique;
        private int grams;

        public Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType 
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                ValidateFlour(value);

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                ValidateTechnique(value);

                this.bakingTechnique = value;
            }
        }

        public int Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                ValidateAmount(value);
                this.grams = value;
            }
        }

        public double GetCalories()
        {
            double flourMod = 1.5;
            if (FlourType.ToLower() == "wholegrain")
            {
                flourMod = 1.0;
            }

            double techniqueMod = 0.9;
            if (BakingTechnique.ToLower() == "chewy")
            {
                techniqueMod = 1.1;
            }
            if (BakingTechnique.ToLower() == "homemade")
            {
                techniqueMod = 1.0;
            }

            return 2 * flourMod * techniqueMod * Grams;
        }

        private static void ValidateFlour(string value)
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException(GlobalConstants.InvalidDoughMsg);
            }
        }

        private static void ValidateTechnique(string value)
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException(GlobalConstants.InvalidDoughMsg);
            }
        }

        private static void ValidateAmount(int value)
        {
            if (value < MIN_AMOUNT || value > MAX_AMOUNT)
            {
                throw new ArgumentException(GlobalConstants.InvalidAmountMsg);
            }
        }
        
    }
}