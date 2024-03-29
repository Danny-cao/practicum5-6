﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageLogicLibrary;
using StoreLogicLibrary;

namespace StoreLogicLibrary
{
    public static class StoreLogicService
    {

        public static bool VerifyLogin(string username, string password)
        {
            //return StoreLogicRepository.Customers.Any(c => c.VerifyLogin(username, password));
            return StoreLogicRepository.checkCustomer(username, password);
        }

        public static bool RegisterCustomer(Customer c)
        {
            if (c.Username != null && c.Username != String.Empty)
            {
                return StoreLogicRepository.GetCustomer(c.Username) == null && StoreLogicRepository.AddCustomer(c);
            }

            return false;
        }

        public static bool BuyProduct(string username, string productNaam, int quantity)
        {
            try
            {
                Console.WriteLine(productNaam);
                var p = StoreLogicRepository.GetProduct(productNaam);
                var c = StoreLogicRepository.GetCustomer(username);

                if (!(p.CheckStock(quantity) && c.CheckBalance(p.Price * quantity))) return false;
                p.LowerStock(quantity);

                Decimal dPrice = (decimal)p.Price * quantity;

                StoreLogicRepository.AddOrder(username, productNaam, quantity, dPrice);

                //c.AddOrder(new CustomerProduct(p.Name, quantity, p.Price));
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static IEnumerable<StoreProduct> GetProducts()
        {
            return StoreLogicRepository.GetProducts().Where(p => p.Stock > 0);
        }

        public static IEnumerable<Order> GetAllOrders(string username)
        {
            try
            {
                return StoreLogicRepository.GetOrders(username);
             
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public static double GetBalance(string username)
        {
            try
            {
                var c = StoreLogicRepository.GetCustomer(username);
                return c.Balance;
            }
            catch (NullReferenceException)
            {
                return -1;
            }
        }
    }
}
