using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Product
    {
        public int count = 1;
        public  string Name { get; set; }
        public double Price { get; set; }
        public string ProductId { get; set; }
        public int InStock { get; set; }
        public int Quantity { get; set; }
        public ProductsVendors Vendor { get; set; }
        public Product() { }
        public Product(string name,double price,string id,int inStock, ProductsVendors vendor,int quantity)
        {
            Name = name;
            Price = price;
            ProductId = id;
            InStock = inStock;
            Vendor = vendor;
            Quantity = quantity;
        }
        public  string PrintProduct()
        {
            return $"Id:{ProductId} Name:{Name}: {Price} MKD";
        }
      
    }
}
