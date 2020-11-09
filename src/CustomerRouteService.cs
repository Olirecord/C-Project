using System;
namespace src
{
    public class CustomerRouteService : IRouter
    {
        readonly Customers Customers;
        
        

        public CustomerRouteService(object customers)
        {
            this.Customers = (Customers)customers;
        }

        public void route()
        {
            Console.WriteLine("Would you like to view or add a Customer?");
            var choice = Console.ReadLine();
            
            if (choice.ToLower() == "view")
            {
                displayCustomer();
            }
            else if (choice.ToLower() == "add")
            {
                addCustomer();
            }
            else
            {
                Console.WriteLine("Please enter either 'View' or 'Add'");
                this.route();
            }


        }

        public void displayCustomer()
        {
            Console.WriteLine("Please enter the customer ID");
            var custId = int.Parse(Console.ReadLine());
            var customer = Customers.filterCust(custId);
            Console.WriteLine("");
            Console.WriteLine(customer);
        }

        public void addCustomer()
        {
            Console.WriteLine("Please enter the name of the customer you wish to add");
            var custToAdd = Console.ReadLine();
            Console.WriteLine(Customers.addCustomer(custToAdd));
        }
    }
}
