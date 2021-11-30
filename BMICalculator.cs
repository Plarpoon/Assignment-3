using System;
using System.Diagnostics;

namespace Assignment_3
{
    internal class BMICalculator
    {
        private string name = "No Name";
        private double height = 0;  //m, feet
        private double weight = 0;  //kg, lb
        private UnitTypes unit;

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
            if (unit == UnitTypes.Metric)
            {
                string heightValue = meterFeet + "," + centimeterInch;
                heightParsing = double.TryParse(heightValue, out height);
            }
            else
            {
                int tempFoot = int.Parse(meterFeet);
                int tempInch = int.Parse(centimeterInch);
                height = (tempFoot * 12) + tempInch;    // in inches.
            }

            return height;
        }

        public UnitTypes GetUnit()
        {
            return unit;
        }

        public void SetUnit(UnitTypes value)
        {
            unit = value;
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
            double temp;
            height = SetHeight();
            //  used formula: http://people.maths.ox.ac.uk/trefethen/bmi.html
            height = Math.Pow(height, 2.5);

            if (unit == UnitTypes.Metric)
            {
                temp = 1.3 * weight / height;
                BMI = Math.Round(temp, 2).ToString();
            }
            else
            {
                temp = 5734 * weight / height;
                BMI = Math.Round(temp, 2).ToString();
                //  why would anyone in their sane mind willingly choose to use Imperial!?
            }

            //  Debugging, use for testing or ignore this section.
            Debug.WriteLine("meterFeet value in the backend is:\n" + meterFeet + "\n");
            Debug.WriteLine("centimeterInch value in the backend is:\n" + centimeterInch + "\n");
            Debug.WriteLine("Weight value in the backend is:\n" + weight + "\n");
            Debug.WriteLine("Height value in the backend is:\n" + height + "\n");
            Debug.WriteLine("BMI value in the backend is:\n" + BMI + "\n");

            return BMI;
        }
    }
}