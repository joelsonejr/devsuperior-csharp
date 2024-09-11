using Course.Entities;

namespace Course.Entities
{
    class IndividualTaxPayer : TaxPayer
    {
        public double HealthExpense { get; set; }

        public IndividualTaxPayer(double healthExpense, string name, double annualIncome) : base(name, annualIncome)
        {
            HealthExpense = healthExpense;
        }

        public override double CalculateTax()
        {
            return 0;
        }
    }
}