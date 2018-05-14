using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator5;

namespace MortgageCalculator.Tests
{
    [TestClass]
    public class CalculateMonthlyPaymentShould
    {
        [TestMethod]
        public void ReturnPurchasePriceDividedByTwelveWhenInterestAndDownPaymentAreZeroAndTermIsOneYear()
        {
            Calculator calc = new Calculator();

            int term = 2;
            decimal purchasePrice = 24;

            var result = calc.CalculateMonthlyPayment(term, 0, purchasePrice, 0);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ReturnResultGreaterThanZeroWhenInterestHasValue()
        {
            Calculator calc = new Calculator();

            int term = 2;
            decimal purchasePrice = 24;
            decimal apr = 0.05M;

            var result = calc.CalculateMonthlyPayment(term, apr, purchasePrice, 0);

            Assert.IsTrue(result > 0);
        }
    }
}
