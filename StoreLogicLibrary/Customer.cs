﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using StorageLogicLibrary;

namespace StoreLogicLibrary
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public double Balance { get; private set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public List<Order> Orders { get; set; } = new List<Order>();

        public Customer(string username)
        {
            Username = username;
            Password = generatePassword();
        }

        public Customer(string username, double b)
        {
            Username = username;
            Password = generatePassword();
            Balance = b;
        }

        private string generatePassword()
        {
            char[] charArray = Username.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public bool VerifyLogin(string username, string password)
        {
            return Username.Equals(username) && Password.Equals(password);
        }

        public bool CheckBalance(double price)
        {
            if (Balance < price) return false;
            return true;
        }

    }
}
