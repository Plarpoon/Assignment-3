namespace Assignment_3
{
    internal class SavingCalculator
    {
        public double amountPaid;
        public double amountEarned;
        public double finalBalance;
        public double totalFees;

        private double initialDeposit;
        private double monthlyDeposit;
        private double periodYears;
        private double growthInterest;
        private double feesPercentage;

        public double GetInitialDeposit()
        {
            return initialDeposit;
        }

        public void SetInitialDeposit(double value)
        {
            initialDeposit = value;
        }

        public double GetMonthlyDeposit()
        {
            return monthlyDeposit;
        }

        public void SetMonthlyDeposit(double value)
        {
            monthlyDeposit = value;
        }

        public double GetPeriodYears()
        {
            return periodYears;
        }

        public void SetPeriodYears(double value)
        {
            periodYears = value;
        }

        public double GetGrowthInterest()
        {
            return growthInterest;
        }

        public void SetGrowthInterest(double value)
        {
            growthInterest = value;
        }

        public double GetFeesPercentage()
        {
            return feesPercentage;
        }

        public void SetFeesPercentage(double value)
        {
            feesPercentage = value;
        }

        public double CalculateAmountPaid() // how much I deposited in the account
        {
            amountPaid = (monthlyDeposit * 12 * periodYears) + initialDeposit;

            return amountPaid;
        }

        public double CalculateAmountEarned()   // how much I earned
        {
            double numberOfMonths = periodYears * 12;
            double balance = 0;

            for (int i = 0; i < numberOfMonths; i++)
            {
                amountEarned = growthInterest * balance;
                balance += growthInterest + monthlyDeposit;
            }

            return amountEarned;
        }

        public double CalculateFinalBalance()   // sum of everything
        {
            finalBalance = amountPaid + amountEarned;   // all minus total fees

            return finalBalance;
        }

        public double CalculateTotalFees()  // percantage lost to taxes of amount earned
        {
            totalFees = (feesPercentage * monthlyDeposit) * periodYears;

            return totalFees;
        }
    }
}