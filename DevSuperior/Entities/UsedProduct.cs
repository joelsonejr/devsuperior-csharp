using System.Globalization;

namespace Course.Entities
{
    class UsedProducts : Product
    {
        public DateOnly ManufactureDate { get; set; }

        public UsedProducts()
        {

        }

        public UsedProducts(string name, double price, DateOnly manufacturedDate)
            : base(name, price)
            {
                ManufactureDate = ManufactureDate;
            }

        public override string PriceTag()
        {   
            string[] tag = base.PriceTag().Split(' ');

            string usedPriceTag = tag[0]
                + " (used) "
                + tag[1]
                + " "
                + Price
                + "(Manufacture date: "
                + ManufactureDate
                + ")";

            return usedPriceTag;
        }
    }
}