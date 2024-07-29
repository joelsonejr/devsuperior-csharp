using System;

namespace Course.Entities
{
    class HourContract 
    {
        public DateTime Date {get; set;}
        public double ValuePerHour {get; set;}
        public int Hours {get; set;}

        public HourContract()
        {

        }

        public HourContract(DateTime date, double valueperHour, int hours)
        {
            Date = date;
            ValuePerHour = valueperHour;
            Hours = hours;
        }

        public double TotalValue() 
        {
            return Hours * ValuePerHour;
        }
    }
}