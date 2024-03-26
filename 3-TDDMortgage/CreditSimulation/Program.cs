namespace CreditSimulation {
    public class Program {
        public static void Main(string[] args) {
            decimal loanAmount = 100000;
            int durationYears = 20;
            decimal interestRate = 5.0m;
            decimal monthlyPayment = CreditCalculator.CalculateMonthlyPayment(loanAmount, durationYears, interestRate);

            string filePath = "monthly_installments.csv";
            CreditCalculator.GenerateCSVFile(filePath, loanAmount, durationYears, interestRate);
        }
    }
}