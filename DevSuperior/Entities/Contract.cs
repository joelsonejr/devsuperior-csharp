using Course.Entities;

namespace Course.Entities
{
    class Contract
    {
        public int ContractNumber { get; set; }
        public DateOnly ContractDate { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract(int contractNumber, DateOnly contractDate, double totalValue)
        {
            ContractNumber = contractNumber;
            ContractDate = contractDate;
            TotalValue = totalValue;
        }
    }
}