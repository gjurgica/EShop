using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Methods
{
    public static class Validations
    {
        public delegate void ChoosePayment(string answer);
        public delegate void ShipInfo(string street, int number, Place place, Provider provider);
        public static int count = 1;
        public static User  CheckUserName(string name,List<User> users)
        {
            do
            {
                Console.WriteLine("Please enter your user name:");
                name = Console.ReadLine();
                foreach (var user in users)
                {
                    if (name == user.UserName)
                    {
                        return user;
                    }
                    Console.WriteLine("This user name don't exist in this page.Try again");
                    break;
                }
            } while (true);
            
        }
        public static void CheckVendor(string vendor,List<Product> products)
        {
            do
            {
                vendor = Console.ReadLine();
                if (vendor == "1")
                {
                    var health = products.Where(product => product.Vendor == ProductsVendors.NaturalWealth).ToList();
                    Console.WriteLine($"{ProductsVendors.NaturalWealth} products:");
                    foreach (var product in health)
                    {

                        Console.WriteLine(product.PrintProduct());
                    }
                    break;
                }
                else if (vendor == "2")
                {
                    var fish = products.Where(product => product.Vendor == ProductsVendors.Maya).ToList();
                    Console.WriteLine($"{ProductsVendors.Maya} products:");
                    foreach (var product in fish)
                    {
                        Console.WriteLine(product.PrintProduct());
                    }
                    break;
                }
                else if (vendor == "3")
                {
                    var cosmetic = products.Where(product => product.Vendor == ProductsVendors.Sephora).ToList();
                    Console.WriteLine($"{ProductsVendors.Sephora} products:");
                    foreach (var product in cosmetic)
                    {
                        Console.WriteLine(product.PrintProduct());
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose number between 1 and 3");
                } 
            } while (vendor != "1" || vendor != "2" || vendor != "3");
        }
        public static void ProductName(string name,List<Product> products)
        {
            name = Console.ReadLine().ToLower();
            Product findProduct = products.Find(product => product.Name.ToLower().Contains(name));
            if(findProduct != null)
            {
                Console.WriteLine(findProduct.PrintProduct());
            }
            else
            {
                Console.WriteLine("This product don't exist in the list");
            }
            
        }
        public static bool ChooseProducts(string order,string answer,List<Product> products,User user1,List<Product> populate)
        {

            Console.WriteLine("Add to cart\nEnter a product Id or choose quit");
            order = Console.ReadLine();
            do
            {
                if (order != "quit")
                {
                    Console.WriteLine("Enter a quantity of product");
                    string quantity = Console.ReadLine();
                    int convertQuantity = int.Parse(quantity);
                    populate.Add(NewOrder(order, convertQuantity, products, CheckUserName(answer, Generator.Users())));
                    return true;
                }
                else
                {
                    Console.WriteLine($"Thank you for shoping");
                    double price = 0.0;
                    foreach (Product product in populate)
                    {
                        price += product.Price * product.Quantity;
                    }
                    Console.WriteLine($"Total price of your shopping is: {price}");
                    CheckYourList(populate);
                    return false;
                }
            } while (order == "quit");
        }
        public static void PayWithCreditCard(string answer)
        {
             Console.WriteLine("You choose credit card");
        }
        public static void PayWithPayPal(string answer)
        {
            Console.WriteLine("You choose PayPal");
        }
        public static void PayInfo(string pay)
        {
            Console.WriteLine("How do you like to pay?\n1.Credit Card\n2.PayPal");
            pay = Console.ReadLine();
            if (pay == "1")
            {
                ChoosePayment card = PayWithCreditCard;
                card(pay);
            }
            else if (pay == "2")
            {
                ChoosePayment paypal = PayWithPayPal;
                paypal(pay);
            }
            else
            {
                Console.WriteLine("Please choose 1 or 2");
            }
        }
        public static void ShipYouOrder(string street,int number,Place place,Provider provider)
        {
            
            Console.WriteLine($"The Ship Info: \nStreet:{street}\nNumber:{number}\nPlace:{place}\nProvider{provider}");

        }
        public static Product NewOrder(string id,int quantity,List<Product> products,User user)
        {
            foreach(Product product in products)
            {
                if (id == product.ProductId)
                {
                    product.Quantity = quantity;
                    user.MakeOrder(product);
                    user.PrintOrders();
                    products.Remove(product);
                    return product;
                } 
            }
            return null;
        } 
        public static void CheckYourList(List<Product> populate)
        {
            Console.WriteLine("Your history list\n1.Cheap orders\n2.Expensive orders");
            string choose = Console.ReadLine();
            if (choose == "1")
            {
                var cheap = populate.Where(product => product.Price <= 1000.00).ToList();
                foreach (var product in cheap)
                {
                    Console.WriteLine(product.PrintProduct());
                }
            }
            else if (choose == "2")
            {
                var expensive = populate.Where(product => product.Price > 1000.00).ToList();
                foreach (var product in expensive)
                {
                    Console.WriteLine(product.PrintProduct());
                }
            }
            else
            {
                Console.WriteLine("Please enter 1 or2");
            }
        }
    }
}
