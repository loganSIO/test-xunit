namespace CreditSimulation {
    public static class CreditCalculator {
        public const decimal MinimumLoanAmount = 50000;
        public const int MinimumDurationYears = 9;
        public const int MaximumDurationYears = 25;

        public static decimal CalculateTotalCostOfCredit(decimal loanAmount, int durationYears, decimal interestRate) {
            decimal monthlyPayment = CalculateMonthlyPayment(loanAmount, durationYears, interestRate);
            int totalMonths = durationYears * 12;
            decimal totalPayments = monthlyPayment * totalMonths;
            decimal totalCostOfCredit = totalPayments - loanAmount;

            return totalCostOfCredit;
        }

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

        public static void GenerateCSVFile(string filePath, decimal loanAmount, int durationYears, decimal interestRate) {

            using (StreamWriter writer = new StreamWriter(filePath)) {

                decimal totalCostOfCredit = CalculateTotalCostOfCredit(loanAmount, durationYears, interestRate);
                writer.WriteLine($"Total Cost of Credit: {totalCostOfCredit}");

                writer.WriteLine("Installment Number, Capital Repaid, Remaining Capital Due");

                decimal remainingCapital = loanAmount;
                decimal monthlyPayment = CalculateMonthlyPayment(loanAmount, durationYears, interestRate);

                for (int i = 1; i <= durationYears * 12; i++) {
                    decimal interestPayment = remainingCapital * (interestRate / 12 / 100);

                    decimal capitalRepaid = monthlyPayment - interestPayment;

                    remainingCapital -= capitalRepaid;

                    writer.WriteLine($"{i}, {capitalRepaid}, {remainingCapital}");

                    if (remainingCapital <= 0) {
                        break;
                    }
                }
            }
        }
    }
}