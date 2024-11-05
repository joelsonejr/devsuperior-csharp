using System.Globalization;

namespace Course.Entities
{
    class Installment
    {
        public DateOnly DueDate { get; set; }
        public double Amount { get; set; }

        public Installment(DateOnly dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }

        override public string ToString()
        {
            return DueDate.ToString("dd/MM/yyyy") + " - " + Amount.ToString("F2", CultureInfo.InvariantCulture);            
        }

        
    }
}