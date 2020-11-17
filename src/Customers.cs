using System;
using System.Collections.Generic;

namespace src
{
    public class Customers
    {
        private readonly List<Customer> custList = new List<Customer>();
        
        

        public Customers() { }
        

        public Customer filterCust(int custId)
        {
            var reponse = custList.Find(r => r.custId == custId);
            return reponse;
        }

        public List<Customer> getCustList()
        {
            return custList;
        }

        public Customer addCustomer(string name)
        {
            int custID = custList.Count+1;
            
            Customer customer = new Customer(custID,name);
            custList.Add(customer);

            
            return customer;
        }

        


    }
}

 

