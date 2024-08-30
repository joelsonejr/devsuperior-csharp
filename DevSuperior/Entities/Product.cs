using System.Globalization;
using System.Text;

namespace Course.Entities
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {

        }

        public Product (string name, double price) 
        {
            Name = name;
            Price = price;
        }

        public virtual string PriceTag()
        {
            string priceTag = Name 
                + " $ " 
                + Price.ToString("F2", CultureInfo.InvariantCulture);

            return priceTag;
        }

    
    }
}