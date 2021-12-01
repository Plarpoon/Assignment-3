using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Assignment_3
{
    public partial class MainWindow
    {
        //  Declare and create an instance of the BMI Calculator.
        private readonly BMICalculator bmiCalc = new();

        //  Declare and create an instance of the SavingCalculator.
        private readonly SavingCalculator savingCalc = new();

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

        private void NumberOnlyValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberAndFloatValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9.]+");
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

        #region Saving Calculator

        private bool InitialDeposit()
        {
            bool ok = double.TryParse(InitialDepositBox.Text, out double deposit);
            if (ok)
            {
                savingCalc.SetInitialDeposit(deposit);
            }
            else
            {
                _ = MessageBox.Show("Invalid deposit value!", "Error");
            }

            return ok;
        }

        private bool MonthlyDeposit()
        {
            bool ok = double.TryParse(MonthlyDepositBox.Text, out double monthlyDeposit);
            if (ok)
            {
                savingCalc.SetMonthlyDeposit(monthlyDeposit);
            }
            else
            {
                _ = MessageBox.Show("Invalid monthly deposit value!", "Error");
            }

            return ok;
        }

        private bool PeriodYears()
        {
            bool ok = double.TryParse(PeriodYearsBox.Text, out double periodYears);
            if (ok)
            {
                savingCalc.SetPeriodYears(periodYears);
            }
            else
            {
                _ = MessageBox.Show("Invalid period value!", "Error");
            }

            return ok;
        }

        private bool GrowthInterest()
        {
            bool ok = double.TryParse(GrowthInterestBox.Text, out double growthInterest);
            if (ok)
            {
                savingCalc.SetGrowthInterest(growthInterest);
            }
            else
            {
                _ = MessageBox.Show("Invalid growth value!", "Error");
            }

            return ok;
        }

        private bool FeesPercentage()
        {
            bool ok = double.TryParse(FeesPercentageBox.Text, out double feesPercentage);
            if (ok)
            {
                savingCalc.SetFeesPercentage(feesPercentage);
            }
            else
            {
                _ = MessageBox.Show("Invalid fees value!", "Error");
            }

            return ok;
        }

        private void Button_CalculateSavings_Click(object sender, RoutedEventArgs e)
        {
            ReadSavingPlanData();
            CalculateSavingPlanData();
            WriteSavingPlanData();
        }

        private void ReadSavingPlanData()
        {
            _ = InitialDeposit();
            _ = MonthlyDeposit();
            _ = PeriodYears();
            _ = GrowthInterest();
            _ = FeesPercentage();
        }

        private void CalculateSavingPlanData()
        {
            _ = savingCalc.CalculateAmountPaid();
            _ = savingCalc.CalculateAmountEarned();
            _ = savingCalc.CalculateTotalFees();
            _ = savingCalc.CalculateFinalBalance();
        }

        private void WriteSavingPlanData()
        {
            AmountPaidLabel.Content = savingCalc.amountPaid;
            AmountEarnedLabel.Content = savingCalc.amountEarned;
            FinalBalanceLabel.Content = savingCalc.finalBalance;
            TotalFeesLabel.Content = savingCalc.totalFees;
        }

        #endregion Saving Calculator

        private void Button_CalculateBMR_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}