
using StoreLogicLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageLogicLibrary;
using System.Diagnostics;

namespace StoreLogicLibrary
{
    static class StoreLogicRepository
    {

        public static List<Customer> Customers = new List<Customer>() { new Customer("test") };

        public static List<StoreProduct> Products = new List<StoreProduct>();

        public static Boolean checkCustomer(string u, string p)
        {

            using (dotNETP5Entities ctx = new dotNETP5Entities())
            {

                var x = (from value in ctx.User
                         where value.Username.Equals(u) && value.Password.Equals(p)
                         select value).FirstOrDefault();

                if (x == null)
                {

                    return false;

                } else
                {

                    return true;

                }

            }

        }

        public static Customer GetCustomer(string username)
        {

            using (dotNETP5Entities ctx = new dotNETP5Entities())
            {

                var u = (from value in ctx.User
                         where value.Username.Equals(username)
                         select value).FirstOrDefault();

                if (u == null)
                {

                    return Customers.FirstOrDefault(c => c.Username.Equals(username));


                } else
                {

                    return new Customer(u.Username, Convert.ToDouble(u.Money));

                }
               
            }
                            
        }

        public static StoreProduct GetProduct(string productNaam)
        {

            using (dotNETP5Entities ctx = new dotNETP5Entities())
            {

                var p = (from value in ctx.Product
                         where value.Name.Equals(productNaam)
                         select value).FirstOrDefault();

                return new StoreProduct(p.Name, p.Stock, Convert.ToDouble(p.Price));

            }

            //return Products.FirstOrDefault(p => p.Name.Equals(productNaam));
        }

        public static bool AddCustomer(Customer c)
        {

            if (c == null) return false;

            using (dotNETP5Entities ctx = new dotNETP5Entities())
            {

                int id = (from value in ctx.User
                          select value.Id).Max() + 1;

                User u = new User(id, c.Username, c.Password, "1000");

                ctx.User.Add(u);
                ctx.SaveChanges();
                return true;

            }

            //if (c == null) return false;
            //Customers.Add(c);
            //return true;
        }

        public static IEnumerable<StoreProduct> GetProducts()
        {

            Products.Clear();

           using (dotNETP5Entities ctx = new dotNETP5Entities()) {

                var products = from p in ctx.Product
                               select p;

                foreach (Product p in products)
                {

                    Products.Add(new StoreProduct(p.Name, p.Stock, Convert.ToDouble(p.Price)));

                }

                return Products;

            }

            //return Products;

        }

        public static Boolean AddOrder(string user, string product, int amount, decimal price)
        {

            using (dotNETP5Entities ctx = new dotNETP5Entities())
            {

                int id = (from value in ctx.Order
                          select value.Id).Max() + 1;

                DateTime now = DateTime.Now;

                Order o = new Order(id, user, now, product, amount, price);

                ctx.Order.Add(o);

                User u = (from value in ctx.User
                          where value.Username.Equals(user)
                          select value).FirstOrDefault();

                Decimal temp = Convert.ToDecimal(u.Money);
                temp -= (amount * price);

                u.Money = temp.ToString();

                Product s = (from value in ctx.Product
                                  where value.Name.Equals(product)
                                  select value).FirstOrDefault();

                s.Stock -= amount;

                ctx.SaveChanges();
                return true;

            }

        }

        public static IEnumerable<Order> GetOrders(string username)
        {

            List<Order> Orders = new List<Order>();

            using (dotNETP5Entities ctx = new dotNETP5Entities())
            {

                var orders = from value in ctx.Order
                             where value.Username.Equals(username)
                             select value;

                foreach(Order o in orders)
                {

                    Orders.Add(o);
                    //Debug.WriteLine(o.Product);

                }

                return Orders;

            }

        }

    }
}
