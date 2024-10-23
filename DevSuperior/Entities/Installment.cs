namespace Couse.Entities
{
    class Installment
    {
        public DateTime InstallmentDate { get; set; }
        public double InstallmentValue { get; set; }

        public Installment(DateTime installmentDate, double installmentValue)
        {
            InstallmentDate = installmentDate;
            InstallmentValue = installmentValue;
        }
    }
}