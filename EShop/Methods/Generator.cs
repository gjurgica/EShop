using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Methods
{
    public static class Generator
    {
        public static List<User> Users()
        {
            return new List<User>
            {
                new User(1,"gjurgica"),
                new User(2,"nikola"),
                new User(3,"irena")
            };
        }
        public static List<Product> ProductsHealth()
        {
            return new List<Product>
            {
                new Product("Omega 3-6-9",995.00,"001",330,ProductsVendors.NaturalWealth,0),
                new Product("Magnesium",456.00,"002",211,ProductsVendors.NaturalWealth,0),
                new Product("Vitamin C",550.00,"003",2,ProductsVendors.NaturalWealth,0),
                new Product("B-Complex",224.00,"004",122,ProductsVendors.NaturalWealth,0),
                new Product("ABC Plus",455.00,"005",143,ProductsVendors.NaturalWealth,0)
            };
        }
        public static List<Product> ProductsFishing()
        {
            return new List<Product>
            {
                new Product("FISHING ASSIST HOOK RED LINE",1800.00,"006",3,ProductsVendors.Maya,0),
                new Product("FISHING WAIST TACKLE BAG BOX",2200.00,"007",22,ProductsVendors.Maya,0),
                new Product("GALAXY FISHING TELESCOPIC SURF ROD",3550.00,"008",12,ProductsVendors.Maya,0),
                new Product("KEVLAR CORE DYNEEMA FISHING LINE",3200.00,"009",123,ProductsVendors.Maya,0),
                new Product("PET CORE DYNEEMA FISHING LINE",1760.00,"010",33,ProductsVendors.Maya,0)
            };
        }
        public static List<Product> ProductsHair()
        {
            return new List<Product>
            {
                new Product("Living Proof",1300.00,"011",45610,ProductsVendors.Sephora,0),
                new Product("Amika",1300.00,"012",333,ProductsVendors.Sephora,0),
                new Product("Moorocanoil",1260.00,"013",43,ProductsVendors.Sephora,0),
                new Product("Klorane",1200.00,"014",90,ProductsVendors.Sephora,0),
                new Product("Bumble and Bumble",1660.00,"016",456,ProductsVendors.Sephora,0)
            };
        }

    }
}
