namespace CreditSimulation.Tests {
    public class CreditCalculatorTests {
        [Theory]
        [InlineData(100000, 20, 5.0, 659.96)]
        public void CalculateMonthlyPayment(decimal loanAmount, int durationYears, decimal interestRate, decimal expectedMonthlyPayment) {

        decimal actualMonthlyPayment = CreditCalculator.CalculateMonthlyPayment(loanAmount, durationYears, interestRate);

        Assert.Equal(expectedMonthlyPayment, actualMonthlyPayment, 2);
        }

        [Fact]
        public void CalculateMonthlyPayment_LoanAmountBelowMinimum_ThrowsArgumentException() {
            decimal loanAmount = 49000;
            int durationYears = 20;
            decimal interestRate = 5.0m;

            Assert.Throws<ArgumentException>(() => CreditCalculator.CalculateMonthlyPayment(loanAmount, durationYears, interestRate));
        }

        [Fact]
        public void CalculateMonthlyPayment_DurationBelowMinimum_ThrowsArgumentException() {
            decimal loanAmount = 100000;
            int durationYears = 8;
            decimal interestRate = 5.0m;

            Assert.Throws<ArgumentException>(() => CreditCalculator.CalculateMonthlyPayment(loanAmount, durationYears, interestRate));
        }

        [Fact]
        public void CalculateMonthlyPayment_DurationAboveMaximum_ThrowsArgumentException() {
            decimal loanAmount = 100000;
            int durationYears = 26;
            decimal interestRate = 5.0m;

            Assert.Throws<ArgumentException>(() => CreditCalculator.CalculateMonthlyPayment(loanAmount, durationYears, interestRate));
        }

        [Fact]
        public void GenerateCSVFile_ContainsTotalCostHeader() {
            decimall totalCostOfCredit = 58389.38m;
            string filePath = "test.csv";

            CreditCalculator.GenerateCSVFile(filePath, totalCostOfCredit);

            string[] lines = File.ReadAllLines(filePath);
            Assert.NotEmpty(lines);

            Assert.StartsWith("Total Cost of Credit", lines[0]);
        }
    }
}