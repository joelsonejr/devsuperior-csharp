using System.Collections.Generic;
using Course.Entities.Enums;

namespace Course.Entities
{
    class Order
    {
        public DateTime Moment {get; set;}
        public OrderStatus Status {get; set;}
        public Client Client {get; set;}
        public List<OrderItem> OrderItems {get; set;} = new List<OrderItem>();

        public Order() {}

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItems.Remove(item);
        }

        public double Total()
        {
            return 2;
        }

    }
}