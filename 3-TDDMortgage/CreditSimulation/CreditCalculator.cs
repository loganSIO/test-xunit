namespace CreditSimulation {
    public static class CreditCalculator {
        private const decimal MinimumLoanAmount = 50000;
        private const int MinimumDurationYears = 9;

        public static decimal CalculateMonthlyPayment(decimal loanAmount, int durationYears, decimal interestRate) {
            if (loanAmount < MinimumLoanAmount) {
                throw new ArgumentException($"Loan amount must be at least {MinimumLoanAmount}");
            }

            int durationMonths = 12 * durationYears;

            decimal monthlyInterestRate = interestRate / 12 / 100;

            decimal monthlyPayment = loanAmount * monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -durationMonths));

            return monthlyPayment;
        }
    }
}