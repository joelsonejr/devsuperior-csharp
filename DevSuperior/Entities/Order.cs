// using System.Collections.Generic;
// using System.Globalization;
// using System.Text;
// using Course.Entities.Enums;

// namespace Course.Entities
// {
//     class Order
//     {
//         public DateTime Moment {get; set;}
//         public OrderStatus Status {get; set;}
//         public Client Client {get; set;}
//         public List<OrderItem> OrderItems {get; set;} = new List<OrderItem>();

//         public Order() {}

//         public Order(DateTime moment, OrderStatus status, Client client)
//         {
//             Moment = moment;
//             Status = status;
//             Client = client;
//         }

//         public void AddItem(OrderItem item)
//         {
//             OrderItems.Add(item);
//         }

//         public void RemoveItem(OrderItem item)
//         {
//             OrderItems.Remove(item);
//         }

//         public double Total()
//         {   
//             double total = 0;
//             foreach (OrderItem item in OrderItems) {
//                 total += item.SubTotal();
//             }

//             return total;
//         }

//         public override string ToString()
//         {
//             StringBuilder sb = new StringBuilder();
            
//             sb.AppendLine();
//             sb.AppendLine("ORDER SUMMARY");
//             sb.Append("Order moment: ");
//             sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
//             sb.Append("Client: ");
//             sb.Append(Client.Name );
//             sb.Append($" ({Client.BirthDate.ToString("dd/MM/yyyy")}) - ");
//             sb.AppendLine(Client.Email);
//             sb.AppendLine("Order items: ");

//             foreach(OrderItem item in OrderItems)
//             {   
//                 sb.Append(item.Product.Name);
//                 sb.Append(", ");
//                 sb.Append($"${item.Product.Price.ToString("F2", CultureInfo.InvariantCulture)}");
//                 sb.Append(", ");
//                 sb.Append($"Quantity: {item.Quantity}, ");
//                 sb.AppendLine($"Subtotal: ${item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)}");
//             }

//             sb.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");

//             return sb.ToString();

//         }

//     }
// }