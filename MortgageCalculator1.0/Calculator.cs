namespace MortgageCalculator5
{
    public class Calculator
    {
        /*
         * M = P * ( (r*(1 + r)^n) / ((1 + r)^n - 1) )
         * 
         * M is monthly payment
         * P is principal
         * r is monthly interest rate
         * n is number of payments (months)
         */

        public Calculator()
        {
        }

        public decimal CalculateMonthlyPayment(int yearsInMortgage, decimal annualInterestRate, decimal purchasePrice, decimal downPayment)
        {
            decimal monthlyPayment = 0.0M;

            decimal principalFinanced = purchasePrice - downPayment;

            decimal monthlyInterestRate = annualInterestRate / 12;

            int monthsInMortgage = yearsInMortgage * 12;

            decimal numerator = 1.0M;

            if (monthsInMortgage > 0)
            {
                numerator = CalculateNumerator(monthlyInterestRate, monthsInMortgage);
            }
            decimal denominator = 1.0M;

            if (monthsInMortgage > 0)
            {
                denominator = CalculateDenominator(monthlyInterestRate, monthsInMortgage);
            }

            if (denominator == 0)
            {
                monthlyPayment = principalFinanced / monthsInMortgage;
            }
            else
            {
                monthlyPayment = principalFinanced * ( numerator / denominator);
            }
            return monthlyPayment;
        }

        private static decimal RaiseDecimalToPowerOfTerm(decimal rate, int term)
        {
            decimal rateToPowerOfTerm = 1;

            int i = 1;

            while (i <= term)
            {
                i++;

                rateToPowerOfTerm = rateToPowerOfTerm * (1 + rate);
            }

            return rateToPowerOfTerm;
        }

        private decimal CalculateNumerator(decimal monthlyRate, int numberOfMonths)
        {
            decimal numeratorPower = RaiseDecimalToPowerOfTerm(monthlyRate, numberOfMonths);

            return monthlyRate * numeratorPower;
        }

        private decimal CalculateDenominator(decimal monthlyRate, int numberOfMonths)
        {
            decimal denominatorPower = RaiseDecimalToPowerOfTerm(monthlyRate, numberOfMonths);

            return denominatorPower - 1;
        }
    }
}
