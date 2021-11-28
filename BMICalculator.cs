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

        public string? BMI;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }

        public string GetMeterFeet()
        {
            return meterFeet;
        }

        public void SetMeterFeet(string MF)
        {
            MF = MF.Trim();
            if (MF.Length != 0 || MF != null)
            {
                meterFeet = MF;
            }
        }

        public string GetCentimeterInch()
        {
            return centimeterInch;
        }

        public void SetCentimeterInch(string CI)
        {
            CI = CI.Trim();
            if (CI.Length != 0 || CI != null)
            {
                centimeterInch = CI;
            }
        }

        public double GetHeight()
        {
            return height;
        }

        public double SetHeight()
        {
            string heightValue = meterFeet + "," + centimeterInch;  //  Need to see this as comma and not just .
            heightParsing = double.TryParse(heightValue, out height);

            return height;
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

        public void SetWeight(double weightTxt)
        {
            if (weightTxt > 0.0)
            {
                weight = weightTxt;
            }
        }

        public string CalculateBMI()
        {
            weight = GetWeight();
            height = SetHeight();

            if (GetUnit() == UnitTypes.Metric)
            {
                BMI = (weight / Math.Sqrt(height)).ToString();
            }
            else
            {
                BMI = (weight / Math.Sqrt(height) * 703).ToString();
                //  why would anyone in their sane mind willingly use Imperial!?
            }

            //  Debugging, ignore this section.
            Debug.WriteLine("meterFeet value in the backend is:\n" + meterFeet + "\n");
            Debug.WriteLine("centimeterInch value in the backend is:\n" + centimeterInch + "\n");
            Debug.WriteLine("Weight value in the backend is:\n" + weight + "\n");
            Debug.WriteLine("Height value in the backend is:\n" + height + "\n");
            Debug.WriteLine("BMI value in the backend is:\n" + BMI + "\n");

            return BMI;
        }
    }
}