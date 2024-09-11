using Course.Entities;

namespace Course.Entities
{
    class CompanyTaxPayer : TaxPayer
    {
        public int QuantityOfEmployees { get; set; }

        public CompanyTaxPayer(int quantityOfEmployees, string name, double annualIncome) : base(name, annualIncome)
        {
            QuantityOfEmployees = quantityOfEmployees;
        }

        public override double CalculateTax()
        {
            return 0;
        }
    }
}