namespace CreditSimulation {
    public static class CreditCalculator {
        public static decimal CalculateMonthlyPayment(decimal loanAmount, int durationYears, decimal interestRate) {

            int durationMonths = 12 * durationYears;

            decimal monthlyInterestRate = interestRate / 12 / 100;

            decimal monthlyPayment = loanAmount * monthlyInterestRate / (1 - (decimal)Math.Pow((double)(1 + monthlyInterestRate), -durationMonths));

            return monthlyPayment;
        }
    }
}