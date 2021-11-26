using System;
using System.Diagnostics;

namespace Assignment_3
{
    internal class BMICalculator
    {
        private string name = "No Name";
        private double height = 0;  //m, feet
        private double weight = 0;  //kg, lb
        private readonly UnitTypes unit;

        private string meterFeet = "0";
        private string centimeterInch = "0";
        public bool heightParsing = false;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
                Debug.WriteLine("Name value in the backend is:\n" + name + "\n");
            }
        }

        public string GetMeterFeet()
        {
            return meterFeet;
        }

        public void SetMeterFeet(string value)
        {
            value = value.Trim();
            if (value.Length != 0 || value != null)
            {
                meterFeet = value;
            }
        }

        public string GetCentimeterInch()
        {
            return centimeterInch;
        }

        public void SetCentimeterInch(string value)
        {
            value = value.Trim();
            if (value.Length != 0 || value != null)
            {
                centimeterInch = value;
            }
        }

        public double GetHeight()
        {
            return height;
        }

        public void SetHeight()
        {
            string MF = GetMeterFeet();
            string CI = GetCentimeterInch();
            string heightValue = MF + CI;
            heightParsing = double.TryParse(heightValue, out height);

            Debug.WriteLine("Height value in the backend is:\n" + height + "\n");
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
            Debug.WriteLine("Weight value in the backend is:\n" + weight + "\n");
            return weight;
        }

        public string CalculateBMI()
        {
            string BMI;
            weight = GetHeight();   //  ERROR: breakpoint signs 0.
            height = GetHeight();   //  ERROR: breakpoint signs 0.

            if (GetUnit() == UnitTypes.Metric)
            {
                BMI = (weight / Math.Sqrt(height)).ToString();
            }
            else
            {
                BMI = (weight / Math.Sqrt(height) * 703).ToString();
                //  why would anyone in their sane mind willingly use Imperial!?
            }

            Debug.WriteLine("BMI value in the backend is:\n" + BMI + "\n");
            return BMI; // ERROR: outputs a NaN.
        }
    }
}