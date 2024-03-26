namespace CreditSimulation {
    public class Program {
        public static void Main(string[] args) {
          if (args.Length < 3) {
            Console.WriteLine("Usage: dotnetrun -- <loanAmount> <durationYears> <interestRate>");
            return;
          }

          if (!decimal.TryParse(args[0], out decimal loanAmount) || loanAmount < CreditCalculator.MinimumLoanAmount) {
            Console.WriteLine($"Loan amount must be at least {CreditCalculator.MinimumLoanAmount}");
            return;
          }

          if (!int.TryParse(args[1], out int durationYears) || durationYears < CreditCalculator.MinimumDurationYears || durationYears > CreditCalculator.MaximumDurationYears) {
            Console.WriteLine($"Duration must be at least between {CreditCalculator.MinimumDurationYears} and {CreditCalculator.MaximumDurationYears} years");
            return;
          }

          if (!decimal.TryParse(args[2], out decimal interestRate) || interestRate < 0) {
            Console.WriteLine("Invalid interest rate");
            return;
          }

          string filePath = "monthly_installments.csv";
          CreditCalculator.GenerateCSVFile(filePath, loanAmount, durationYears, interestRate);
        }
    }
}