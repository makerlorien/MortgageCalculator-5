namespace MortgageCalculator4
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

            decimal numeratorPower = 0;

            if (monthsInMortgage > 0)
            {
                numeratorPower = RaiseDecimalToPowerOfTerm(monthlyInterestRate, monthsInMortgage);
            }

            decimal denominatorPower = 0;

            if (monthsInMortgage > 0)
            {
                denominatorPower = RaiseDecimalToPowerOfTerm(monthlyInterestRate, monthsInMortgage);
            }

            if (denominatorPower == 1)
            {
                // Prevent divide by zero error
                monthlyPayment = principalFinanced / monthsInMortgage;
            }
            else
            {
                monthlyPayment = principalFinanced * ((monthlyInterestRate * numeratorPower) / (denominatorPower - 1));
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
    }
}
