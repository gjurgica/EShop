using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> Products = new List<Product>();
            Products.AddRange(Methods.Generator.ProductsHealth());
            Products.AddRange(Methods.Generator.ProductsFishing());
            Products.AddRange(Methods.Generator.ProductsHair());
            List<Product> PurchasedOrders = new List<Product>();
            List<User> users = Methods.Generator.Users();
            string answer = "";
            string order = "";
            string pay = "";
            User user1 = Methods.Validations.CheckUserName(answer, Methods.Generator.Users());
            do
            {
                Console.WriteLine("Choose your search:\n1.Based of vendors name\n2.Based of products name\n3.Sorted by Product Name\n4.Sorted by Product Price\n5.Sorting by descending price");
                answer = Console.ReadLine();
                if(answer == "1")
                {
                    Console.WriteLine($"Choose vendor:\n\t1.{ProductsVendors.NaturalWealth}\n\t2.{ProductsVendors.Maya}\n\t3.{ProductsVendors.Sephora}");
                    Methods.Validations.CheckVendor(answer, Products);
                    if(Methods.Validations.ChooseProducts(order, answer, Products, user1, PurchasedOrders) == false)
                    {
                        break;
                    }
                       
                }
                else if(answer == "2")
                {
                    Console.WriteLine("Enter a product name");
                    string product = "";
                    Methods.Validations.ProductName(product, Products);
                    if(Methods.Validations.ChooseProducts(order, answer, Products, user1, PurchasedOrders) == false)
                    {
                        break;
                    }
                }
                else if(answer == "3")
                {
                    Console.WriteLine("Sorted By ProductName:");
                    var sortedProductByName = Products.OrderBy(product => product.Name).ToList();
                    foreach(var product in sortedProductByName)
                    {
                        Console.WriteLine(product.PrintProduct());
                    }
                    if(Methods.Validations.ChooseProducts(order, answer, Products,user1, PurchasedOrders) == false)
                    {
                        break;
                    }
                }
                else if(answer == "4")
                {
                    Console.WriteLine("Sorted By Produc Price:");
                    var sortedProductByPrice = Products.OrderBy(product => product.Price).ToList();
                    foreach (var product in sortedProductByPrice)
                    {
                        Console.WriteLine(product.PrintProduct());
                    }
                    if(Methods.Validations.ChooseProducts(order, answer, Products,user1, PurchasedOrders) == false)
                    {
                        break;
                    }
                }
                else if(answer == "5")
                {
                    Console.WriteLine("Sorted By Produc Price:");
                    var sortedProductByPrice = Products.OrderByDescending(product => product.Price).ToList();
                    foreach (var product in sortedProductByPrice)
                    {
                        Console.WriteLine(product.PrintProduct());
                    }
                    if(Methods.Validations.ChooseProducts(order, answer, Products,user1, PurchasedOrders) == false)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter number between 1 and 5");
                }
            } while (order != "quit");
            Methods.Validations.PayInfo(pay);
            string street = "";
            Console.WriteLine("Enter your street");
            street = Console.ReadLine();
            Console.WriteLine("Enter your number");
            string strNum = Console.ReadLine();
            int number = int.Parse(strNum);
            string strPlace = "";
            Place place = Place.Skopje;
            do
            {
                Console.WriteLine("Enter your place:\n1.Skopje\n2.Ohrid\n3.Bitola\n4.Stip");
                strPlace = Console.ReadLine();
                if (strPlace == "1")
                {
                    place = Place.Skopje;
                    break;
                }
                else if(strPlace == "2")
                {
                    place = Place.Ohrid;
                    break;
                }
                else if(strPlace == "2")
                {
                    place = Place.Bitola;
                    break;
                }
                else if(strPlace == "4")
                {
                    place = Place.Stip;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter number between 1 and 4");
                }
            } while (strPlace != "1" || strPlace != "2" || strPlace != "3" || strPlace != "4");
            string strProvider = "";
            Provider provider = Provider.MakedonskaPosta;
            do
            {
                Console.WriteLine("Enter your provider\n1.Makedonski Posti\n2.Delco");
                strProvider = Console.ReadLine();
                if(strProvider == "1")
                {
                    provider = Provider.MakedonskaPosta;
                    break;
                }
                else if(strProvider == "2")
                {
                    provider = Provider.Delco;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2");
                }
            } while (strProvider != "1" || strProvider != "2");
            Methods.Validations.ShipInfo info = Methods.Validations.ShipYouOrder;
            info(street, number, place, provider);
            Console.ReadLine();
        }
    }
}
