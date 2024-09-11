
namespace Course.Entities
{
    abstract class TaxPayer
    {
        public string Name { get; set; }
        public double AnnualIncome { get; set; }


        public TaxPayer(string name, double annualIncome) {
            Name = name;
            AnnualIncome = AnnualIncome;
        }

        public abstract double CalculateTax();
    }
}