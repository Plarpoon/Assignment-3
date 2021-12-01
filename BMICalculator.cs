using System;
using System.Diagnostics;

namespace Assignment_3
{
    internal class BMICalculator
    {
        //  formula: http://people.maths.ox.ac.uk/trefethen/bmi.html

        public string name = "No Name";
        private double height;  //m, feet
        private double weight;  //kg, lb
        public UnitTypes unit;

        private string meterFeet = "0";
        private string centimeterInch = "0";
        public bool heightParsing;

        public double BMI;
        public string weightCategory = "no weight category";
        public bool normalWeight;
        public string CalculateBmiTarget = "Normal BMI should be between 19 – 24,9 ";

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

        public double CalculateBMI()
        {
            double temp;
            _ = SetHeight();
            height = Math.Pow(height, 2.5);

            if (unit == UnitTypes.Metric)
            {
                temp = 1.3 * weight / height;
                BMI = Math.Round(temp, 2);
            }
            else
            {
                temp = 5734 * weight / height;
                BMI = Math.Round(temp, 2);
                //  why would anyone in their sane mind willingly choose to use Imperial!?
            }

            //  Debugging, use it for testing or ignore this section.
            Debug.WriteLine("meterFeet value in the backend is:\n" + meterFeet + "\n");
            Debug.WriteLine("centimeterInch value in the backend is:\n" + centimeterInch + "\n");
            Debug.WriteLine("Weight value in the backend is:\n" + weight + "\n");
            Debug.WriteLine("Height value in the backend is:\n" + height + "\n");
            Debug.WriteLine("BMI value in the backend is:\n" + BMI + "\n");
            //  End of Debugging text.

            return BMI;
        }

        public string GetWeightCategory()
        {
            return weightCategory;
        }

        public void SetWeightCategory()
        {
            switch (BMI)
            {
                case < 14.9:
                    {
                        weightCategory = "severely underweight";
                        normalWeight = false;
                        break;
                    }
                case < 17.9:
                    {
                        weightCategory = "significantly underweight";
                        normalWeight = false;
                        break;
                    }
                case < 18.9:
                    {
                        weightCategory = "slightly underweight";
                        normalWeight = false;
                        break;
                    }
                case < 24.9:
                    {
                        weightCategory = "normal weight";
                        normalWeight = true;
                        break;
                    }
                case < 29.9:
                    {
                        weightCategory = "slightly overweight";
                        normalWeight = false;
                        break;
                    }
                case < 34.9:
                    {
                        weightCategory = "significantly overweight";
                        normalWeight = false;
                        break;
                    }
                case < 39.9:
                    {
                        weightCategory = "severely obese";
                        normalWeight = false;
                        break;
                    }
                case > 40.0:
                    {
                        weightCategory = "patologically obese";
                        normalWeight = false;
                        break;
                    }
            }
        }
    }
}