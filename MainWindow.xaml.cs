using System;
using System.Windows;

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

        private void UnitImperial_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            //  When Unit Imperial is selected do the below.
            UnitMetric.IsChecked = false;
            BmiCalculatorHeight.Content = "Height ('ft' and 'in')";
            BmiCalculatorWeight.Content = "Weight (lbs)";
        }

        private void UnitMetric_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            //  When Unit Metric is selected do the below.
            UnitImperial.IsChecked = false;
            BmiCalculatorHeight.Content = "Height ('m' and 'cm')";
            BmiCalculatorWeight.Content = "Weight (kg)";
        }

        private void Button_CalculateBMI_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ReadInputBMI();
        }

        private bool ReadInputBMI()
        {
            bool name = ReadName();
            bool height = ReadHeight();
            bool weight = ReadWeight();

            return name && height && weight;
        }

        private bool ReadName()
        {
            bool ok;
            string name = NameContent.Text;
            name = name.Trim();
            if (name == null || name.Length == 0)
            {
                RepeatedName.Text = name;
                ok = true;
            }
            else
            {
                ok = false;
            }

            if (!ok)
                MessageBox.Show("Please input a name!", "Error");

            return ok;
        }

        private bool ReadWeight()
        {
            throw new NotImplementedException();
        }

        private bool ReadHeight()
        {
            string height = HeightContent1.Text + HeightContent2.Text;
            bool ok = double.TryParse(height, out double outValue);
            if (ok)
                if (outValue > 0)   //  Height cannot be zero or negative
                {
                    if (bmiCalc.GetUnit() == UnitTypes.Imperial)
                    {
                        bmiCalc.SetHeight(outValue * 12.00);
                    }
                    else
                    {
                        bmiCalc.SetHeight(outValue / 100.0);
                    }
                }
                else
                {
                    ok = false;
                }

            if (!ok)
                MessageBox.Show("Invalid height value!", "Error");

            return ok;
        }

        private void Button_CalculateSavings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void Button_CalculateBMR_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }
    }
}