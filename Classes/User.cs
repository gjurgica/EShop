using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public int count = 1;
        public List<Product> Orders = new List<Product>();
        public User() { }
        public User(int id,string userName)
        {
            CustomerId = id;
            UserName = userName;
        }
        public void MakeOrder(Product product)
        {
            Orders.Add(product);
        }
        public void PrintOrders()
        {
            Console.WriteLine($"Name:{UserName}");
            foreach (var order in Orders)
            {
                Console.WriteLine($"Product Name: {order.Name} Quantity: {order.Quantity} Price: {order.Price}");
                var price = order.Price * order.Quantity;
                Console.WriteLine($"Total price of this product is: {price}");
            }
        }
        public void RemoveOrder()
        {
            Console.WriteLine("Enter a Id of product who would be removed ");
            string id = Console.ReadLine();
            foreach(var order in Orders)
            {
                if(id == order.ProductId)
                {
                    Orders.Remove(order);
                }
            }
        }
       
    }
}
