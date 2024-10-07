using System.Globalization;

namespace Course.Entities
{
    public class Products
    {
        public string ProdName { get; set; }
        public double ProdPrice { get; set; }
        public int ProdAmount { get; set; }
        public double ProdValue { get; private set;}
        

        public Products () 
        {

        }

        public Products (string prodName, double prodPrice, int prodAmount) 
        {
            ProdName = prodName;
            ProdPrice = prodPrice;
            ProdAmount = prodAmount;
            ProdValue = prodPrice * prodAmount;
        }

        override public string ToString ()
        {
            return ProdName
            + ", "
            + ProdValue.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}