using System;
namespace src
{
    public class CustomerRouteService : IRouter
    {
        readonly Customers Customers;
        Terminal terminal = new Terminal();
        
        

        public CustomerRouteService(object customers)
        {
            this.Customers = (Customers)customers;
        }

        public void route()
        {
            terminal.printStatement("Would you like to view or add a Customer?");
            var choice = terminal.returnStatement();
            
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
                terminal.printStatement("Please enter either 'View' or 'Add'");
                this.route();
            }


        }

        public void displayCustomer()
        {
            terminal.printStatement("Please enter the customer ID");
            var custId = int.Parse(terminal.returnStatement());
            var customer = Customers.filterCust(custId);
            terminal.printStatement("");
            terminal.printCustomer(customer);
        }

        public void addCustomer()
        {
            terminal.printStatement("Please enter the name of the customer you wish to add");
            var custToAdd = Console.ReadLine();
            terminal.printCustomer(Customers.addCustomer(custToAdd));
        }
    }
}
