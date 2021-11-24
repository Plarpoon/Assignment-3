using System;

namespace Assignment_3
{
    internal class BMICalculator
    {
        private string name = "No Name";
        private double height;  //m, feet
        private readonly double weight;  //kg, lb
        private readonly UnitTypes unit;

        private readonly int meterFeet;
        private readonly int centimeterInch;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            if (!string.IsNullOrEmpty(value))
                name = value;
        }

        public double GetMeterFeet()
        {
            return meterFeet;
        }

        public double GetCentimeterInch()
        {
            return centimeterInch;
        }

        public double GetHeight()
        {
            return height;
        }

        public void SetHeight(double value)
        {
            if (value >= 0)
                height = value;
        }

        public UnitTypes GetUnit()
        {
            return unit;
        }

        public UnitTypes SetUnit()
        {
            return unit;
        }

        public void GetWeight(double value)
        {
            if (value >= 0)
                height = value;
        }

        public double SetWeight()
        {
            return weight;
        }

        public double CalculateBMI()
        {
            throw new NotImplementedException();
        }
    }
}