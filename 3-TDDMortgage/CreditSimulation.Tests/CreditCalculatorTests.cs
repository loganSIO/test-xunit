namespace CreditSimulation.Tests {
    public class CreditCalculatorTests {
        [Theory]
        [InlineData(100000, 20, 5.0, 659.96)]
        public void CalculateMonthlyPayment(decimal loanAmount, int durationYears, decimal interestRate, decimal expectedMonthlyPayment) {

        decimal actualMonthlyPayment = CreditCalculator.CalculateMonthlyPayment(loanAmount, durationYears, interestRate);

        Assert.Equal(expectedMonthlyPayment, actualMonthlyPayment, 2);
        }
    }
}