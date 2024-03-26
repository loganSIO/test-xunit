namespace CreditSimulation {
    public class Program {
        public static void Main(string[] args) {
            decimal loanAmount = 100000;
            int durationMonths = 20;
            decimal interestRate = 5.0m;
            decimal monthlyPayment = CreditCalculator.CalculateMonthlyPayment(loanAmount, durationMonths, interestRate);
        }
    }
}