using System;

namespace Course.Entities
{
    public class OrderItem
    {
        public int Quantity {get; set;}
        public double Price {get; set;}
        public Product02 Product {get; set;}

        public OrderItem() {}

        public OrderItem(int quantity, double price, Product02 product) {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal() 
        {
            return Quantity * Price;
        }
    }
}