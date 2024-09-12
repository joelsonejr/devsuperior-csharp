namespace Course.Entities
{
    class IndividualTaxPayer : TaxPayers
    {
        public double HealthExpense { get; set; }

        public IndividualTaxPayer(double healthExpense, string name, double annualIncome) : base(name, annualIncome)
        {
            HealthExpense = healthExpense;
        }

        public override double CalculateTax()
        {
            double taxRate = AnnualIncome < 20000.00 ? 0.15 : 0.25;
            double taxDiscount = HealthExpense / 2; 

            double taxOverIncome = AnnualIncome * taxRate - taxDiscount;

            return taxOverIncome;
        }
    }
}