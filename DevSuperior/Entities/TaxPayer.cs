
namespace Course.Entities
{
    abstract class TaxPayers
    {
        public string Name { get; set; }
        public double AnnualIncome { get; set; }


        public TaxPayers(string name, double annualIncome) {
            Name = name;
            AnnualIncome = annualIncome;
        }

        public abstract double CalculateTax();
    }
}