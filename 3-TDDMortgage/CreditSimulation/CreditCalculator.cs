namespace CreditSimulation {
    public static class CreditCalculator {
        private const decimal MinimumLoanAmount = 50000;
        private const int MinimumDurationYears = 9;
        private const int MaximumDurationYears = 25;

        public static decimal CalculateMonthlyPayment(decimal loanAmount, int durationYears, decimal interestRate) {
            if (loanAmount < MinimumLoanAmount) {
                throw new ArgumentException($"Loan amount must be at least {MinimumLoanAmount}");
            }

            if (durationYears < MinimumDurationYears || durationYears > MaximumDurationYears) {
                throw new ArgumentException($"Duration must be at least between {MinimumDurationYears} and {MaximumDurationYears} years");
            }

            int durationMonths = 12 * durationYears;

            decimal monthlyInterestRate = interestRate / 12 / 100;

            decimal monthlyPayment = loanAmount * monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -durationMonths));

            return monthlyPayment;
        }

        public static void GenerateCSVFile(string filePath, decimal totalCostOfCredit) {

            using (StreamWriter writer = new StreamWriter(filePath)) {
                writer.WriteLine("Total Cost of Credit, " + totalCostOfCredit);
            }
        }
    }
}