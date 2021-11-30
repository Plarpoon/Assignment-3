using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Assignment_3
{
    public partial class MainWindow
    {
        //  Declare and create an instance of the BMI Calculator.
        private readonly BMICalculator bmiCalc = new();

        ////  Declare and create an instance of the SavingCalculator.
        //private readonly SavingCalculator savingCalc = new();

        ////  Declare and create an instance of the BMR Calculator.
        //private readonly BMRCalculator bmrCalc = new();

        public MainWindow()
        {
            InitializeComponent();  //  Required by WPF Library.
            InitializeGui();
        }

        private void InitializeGui()
        {
            BmrCalculatorResults.Items.Clear();
            UnitMetric.IsChecked = true;
            CalculateBmiResult.Text = string.Empty;
            CalculateBmiTarget.Text = string.Empty;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #region BMI Calculator

        private void UnitImperial_Checked(object sender, RoutedEventArgs e)
        {
            //  When Unit Imperial is selected do the below.
            UnitMetric.IsChecked = false;
            BmiCalculatorHeight.Content = "Height ('ft' and 'in')";
            BmiCalculatorWeight.Content = "Weight (lbs)";
        }

        private void UnitMetric_Checked(object sender, RoutedEventArgs e)
        {
            //  When Unit Metric is selected do the below.
            UnitImperial.IsChecked = false;
            BmiCalculatorHeight.Content = "Height ('m' and 'cm')";
            BmiCalculatorWeight.Content = "Weight (kg)";
        }

        private void Button_CalculateBMI_Click(object sender, RoutedEventArgs e)
        {
            //  prep phase.
            MeasurementUnit();
            _ = GetName();
            WriteRepeatedName();
            HeightBuilder();
            _ = WriteWeight();

            //  BMI phase.
            _ = bmiCalc.CalculateBMI();
            BMIbox.Content = bmiCalc.BMI.ToString();

            //  Weight category phase.
            bmiCalc.SetWeightCategory();
            Weight_Category.Content = bmiCalc.weightCategory;

            //  Green indication phase and
            //  Non standard weight indication phase.
            if (bmiCalc.normalWeight == false)
            {
                CalculateBmiResult.Text = bmiCalc.CalculateBmiTarget;
                switch (bmiCalc.unit)
                {
                    case UnitTypes.Metric:
                        {
                            CalculateBmiTarget.Text = "Normal weight should be between 75 and 80 kilos";
                            break;
                        }
                    case UnitTypes.Imperial:
                        {
                            CalculateBmiTarget.Text = "Normal weight should be between 165 and 175 libs";
                            break;
                        }
                }   //  I couldn't really understand what was required to be written under "normal weight" as it vastly differs
                    //  with age, height, body type, gender and muscolar tone so I just used the link provided in your PDF
                    //  and made an average using the chart at the bottom of the page: https://www.thecalculatorsite.com/health/bmicalculator.php
            }
        }

        private void MeasurementUnit()
        {
            UnitTypes value;
            if (UnitMetric.IsChecked == true)
            {
                value = UnitTypes.Metric;
                bmiCalc.SetUnit(value);
            }
            else
            {
                value = UnitTypes.Imperial;
                bmiCalc.SetUnit(value);
            }
        }

        private void HeightBuilder()
        {
            string MF = HeightContent1.Text;
            string CI = HeightContent2.Text;

            bmiCalc.SetCentimeterInch(CI);
            bmiCalc.SetMeterFeet(MF);
        }

        private bool WriteWeight()
        {
            bool ok = double.TryParse(WeightContent.Text, out double weightTxt);
            if (ok)
            {
                bmiCalc.SetWeight(weightTxt);
            }
            else
            {
                _ = MessageBox.Show("Invalid weight value!", "Error");
            }

            return ok;
        }

        private bool GetName()
        {
            bool ok;
            string value = NameContent.Text;
            value = value.Trim();
            if (value == null || value.Length == 0)
            {
                ok = false;
            }
            else
            {
                bmiCalc.SetName(value);
                ok = true;
            }

            if (!ok)
                _ = MessageBox.Show("Please input a name!", "Error");

            return ok;
        }

        private void WriteRepeatedName()
        {
            RepeatedName.Text = bmiCalc.name;
        }

        #endregion BMI Calculator

        private void Button_CalculateSavings_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_CalculateBMR_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}