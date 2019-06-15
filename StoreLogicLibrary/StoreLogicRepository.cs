
using StoreLogicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageLogicLibrary;

namespace StoreLogicLibrary
{
    static class StoreLogicRepository
    {

        public static List<Customer> Customers = new List<Customer>() { new Customer("test") };
        public static List<StoreProduct> Products = new List<StoreProduct>() {
            new StoreProduct("Pineapple Kush", 10, 800),
            new StoreProduct("Silver Haze", 5, 2.50),
            new StoreProduct("Buddha Bubble", 6, 6),
            new StoreProduct("S5 Amnesia Haze", 8, 18),
            new StoreProduct("Moonrock", 9, 15),
            new StoreProduct("LA Confidential", 4, 4.99),
        };

        public static Customer GetCustomer(string username)
        {
            return Customers.FirstOrDefault(c => c.Username.Equals(username));
        }

        public static StoreProduct GetProduct(string productNaam)
        {
            return Products.FirstOrDefault(p => p.Name.Equals(productNaam));
        }

        public static bool AddCustomer(Customer c)
        {
            if (c == null) return false;
            Customers.Add(c);
            return true;
        }

        public static IEnumerable<StoreProduct> GetProducts()
        {
            return Products;
        }
    }
}
