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
            OutputBMI();
        }

        private void OutputBMI()
        {
            WriteName();
            WriteBMI();
        }

        private void WriteBMI()
        {
            WriteName();
            BMIbox.Text = bmiCalc.CalculateBMI();
        }

        public bool ReadInputBMI()
        {
            bool height = ReadHeight();
            bool weight = ReadWeight();

            return height && weight;
        }

        private bool WriteName()
        {
            bool ok;
            string name = NameContent.Text;
            name = name.Trim();
            if (name == null || name.Length == 0)
            {
                ok = false;
            }
            else
            {
                RepeatedName.Text = name;
                ok = true;
            }

            if (!ok)
                MessageBox.Show("Please input a name!", "Error");

            return ok;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool ReadWeight()
        {
            bool ok;
            double weight = bmiCalc.GetWeight();
            if (weight != 0)
            {
                bmiCalc.SetWeight();
                ok = true;
            }
            else
            {
                ok = false;
            }

            if (ok)
                MessageBox.Show("Invalid weight value!", "Error");

            return ok;
        }

        private bool ReadHeight()
        {
            bool ok = bmiCalc.heightParsing;
            if (ok)
            {
                bmiCalc.SetHeight();
                ok = true;
            }
            else
            {
                ok = false;
            }

            if (ok)
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