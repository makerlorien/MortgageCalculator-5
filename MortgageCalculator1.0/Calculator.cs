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

        public decimal CalculateMonthlyPayment(int y, decimal ar, decimal pp, decimal dp)
        {
            decimal M = 0.0M;

            // Amount financed
            decimal P = pp - dp;

            // Monthly rate
            decimal r = ar / 12;

            // Months of payments
            int n = y * 12;

            decimal x = 0;

            if (n > 0)
            {
                // Power formula for the numerator
                decimal temp = 1;

                int i = 0;

                while (i < n)
                {
                    i++;

                    temp = temp * (1 + r);
                }

                x = temp;
            }

            decimal z = 0;

            if (n > 0)
            {
                // Power formula for the denominator
                decimal temp = 1;

                int i = 1;

                while (i <= n)
                {
                    temp = temp * (1 + r);
                    i++;
                }

                z = temp;
            }

            if (z == 1)
            {
                // Prevent divide by zero error
                M = P / n;
            }
            else
            {
                M = P * ((r * x) / (z - 1));
            }
            return M;
        }
    }
}
