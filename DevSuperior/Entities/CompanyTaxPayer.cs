namespace Course.Entities
{
    class CompanyTaxPayer : TaxPayers
    {
        public int QuantityOfEmployees { get; set; }

        public CompanyTaxPayer(int quantityOfEmployees, string name, double annualIncome) : base(name, annualIncome)
        {
            QuantityOfEmployees = quantityOfEmployees;
        }

        public override double CalculateTax()
        {
            double taxRate = QuantityOfEmployees > 10 ? 0.14 : 0.16; 

            double taxOverIncome = AnnualIncome * taxRate;

            return taxOverIncome;
        }
    }
}