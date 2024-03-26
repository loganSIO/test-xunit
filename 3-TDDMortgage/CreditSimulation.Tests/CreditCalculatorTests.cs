namespace CreditSimulation.Tests {
    public class CreditCalculatorTests {

        [Fact]
        public void CalculateTotalCostOfCredit() {

            decimal loanAmount = 100000;
            int durationMonths = 12 * 20;
            decimal interestRate = 5.0m;

            decimal expectedTotalCost = 38955.0m;

            decimal actualTotalCost = CreditCalculator.CalculateTotalCostOfCredit(loanAmount, durationMonths, interestRate);

            Assert.Equal(expectedTotalCost, actualTotalCost, 2);
        }
    }
}