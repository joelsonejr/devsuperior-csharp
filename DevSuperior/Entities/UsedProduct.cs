using System.Globalization;

namespace Course.Entities
{
    class UsedProducts : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProducts()
        {

        }

        public UsedProducts(string name, double price, DateTime manufacturedDate)
            : base(name, price)
            {
                ManufactureDate = manufacturedDate;
            }

        public override string PriceTag()
        {   
            string[] tag = base.PriceTag().Split(' ');

            string usedPriceTag = tag[0]
                + " (used) "
                + tag[1]
                + " "
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + " (Manufacture date: "
                + ManufactureDate.ToString("dd/MM/yyyy")
                + ")";

            return usedPriceTag;
        }
    }
}