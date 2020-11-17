using System;
namespace src
{
    public class AccountRouteService : IRouter
    {
        readonly Customers Customers;
        Terminal terminal = new Terminal();

        public AccountRouteService(object customers)
        {
            this.Customers = (Customers)customers;
        }

        public void route()
        {
            terminal.printStatement("Would you like to view or add a Account?");
            var choice = terminal.returnStatement();
            if (choice.ToLower() == "view")
            {
                terminal.printStatement("Please enter your customer ID");
                int custId = int.Parse(terminal.returnStatement());
                var customer = Customers.filterCust(custId);

                displayAccounts(customer);
            }
            else if (choice.ToLower() == "add")
            {
                terminal.printStatement("Please enter your customer ID");
                var custID = int.Parse(terminal.returnStatement());
                var customer = Customers.filterCust(custID);

                terminal.printStatement("Please enter overdraft amount");
                int overdraftAmount = int.Parse(terminal.returnStatement());

                terminal.printStatement("Please enter ballance");
                int ballance = int.Parse(terminal.returnStatement());

                terminal.printAccount(customer.addAccount(overdraftAmount, ballance));
            }
            else
            {
                terminal.printStatement("Please enter either 'View' or 'Add'");
                this.route();
            }
        }

        public void displayAccounts(Customer customer)
        {
            if (customer.getAccounts().Count > 1)
            {
                terminal.printStatement($"Please enter {customer.custName}'s account number");
                var accountNo = int.Parse(terminal.returnStatement());
                var account = customer.filterAccount(accountNo);
                terminal.printStatement("");
                terminal.printAccount(account);
            }
            else
            {
                var account = customer.getAccounts()[0];
                terminal.printStatement("");
                terminal.printAccount(account);
            }
        }
    }
}
