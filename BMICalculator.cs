using System;

namespace Assignment_3
{
    internal class BMICalculator
    {
        private string name = "No Name";
        private double height = 0;  //m, feet
        private double weight = 0;  //kg, lb
        private UnitTypes unit;

        private int meterFeet = 0;
        private int centimeterInch = 0;

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

            double heightCombined = meterFeet + centimeterInch;
        }

        public UnitTypes GetUnit()
        {
            return unit;
        }

        public UnitTypes SetUnit()
        {
            return unit;
        }

        public double GetWeight()
        {
            return weight;
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