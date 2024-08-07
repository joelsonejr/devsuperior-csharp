using System;

namespace Course.Entities
{
    public class OrderItem
    {
        public int Quantity {get; set;}
        public double Price {get; set;}
        public Product Product {get; set;}

        public OrderItem() {}

        public OrderItem(int quantity, double price, Product product) {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public static double SubTotal(int Quantity, double Price) 
        {
            return Quantity * Price;
        }
    }
}