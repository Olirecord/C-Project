using System;
using System.Collections.Generic;

namespace src
{
    class Customers
    {
        private readonly List<Customer> custList = new List<Customer>();
        
        

        public Customers()
        {
            Customer customer = new Customer(1, "Oli");
            custList.Add(customer);
        }

        public Customer filterCust(int custId)
        {
            var reponse = custList.Find(r => r.custId == custId);
            return reponse;
        }

        public List<Customer> getCustList()
        {
            return custList;
        }

        public string addCustomer(string name)
        {
            int count = 0;
            foreach(Customer data in custList)
            {
                if(data.custId > count)
                {
                    count = data.custId + 1;
                }
            }
            Customer customer = new Customer(count,name);
            custList.Add(customer);

            var confirmation = $"{name} has been added and their ID number is {count}";
            return confirmation;
        }

        


    }
}

 

