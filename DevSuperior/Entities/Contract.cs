using Couse.Entities;

namespace Course.Entities
{
    class Contract
    {
        public int ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public double ContractValue { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract(int contractNumber, DateTime contractDate, double contractValue)
        {
            ContractNumber = contractNumber;
            ContractDate = contractDate;
            ContractValue = contractValue;
        }
    }
}