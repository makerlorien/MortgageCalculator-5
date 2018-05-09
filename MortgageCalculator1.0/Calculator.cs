namespace MortgageCalculator2
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

            decimal x = 0;

            if (monthsInMortgage > 0)
            {
                // Power formula for the numerator
                decimal temp = 1;

                int i = 0;

                while (i < monthsInMortgage)
                {
                    i++;

                    temp = temp * (1 + monthlyInterestRate);
                }

                x = temp;
            }

            decimal z = 0;

            if (monthsInMortgage > 0)
            {
                // Power formula for the denominator
                decimal temp = 1;

                int i = 1;

                while (i <= monthsInMortgage)
                {
                    temp = temp * (1 + monthlyInterestRate);
                    i++;
                }

                z = temp;
            }

            if (z == 1)
            {
                // Prevent divide by zero error
                monthlyPayment = principalFinanced / monthsInMortgage;
            }
            else
            {
                monthlyPayment = principalFinanced * ((monthlyInterestRate * x) / (z - 1));
            }
            return monthlyPayment;
        }
    }
}
