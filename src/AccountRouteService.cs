using System;
namespace src
{
    public class AccountRouteService : IRouter
    {
        readonly Customers Customers;

        public AccountRouteService(object customers)
        {
            this.Customers = (Customers)customers;
        }

        public void route()
        {
            Console.WriteLine("Would you like to view or add a Account?");
            var choice = Console.ReadLine();
            if (choice.ToLower() == "view")
            {
                Console.WriteLine("Please enter your customer ID");
                int custId = int.Parse(Console.ReadLine());
                var customer = Customers.filterCust(custId);

                displayAccounts(customer);
            }
            else if (choice.ToLower() == "add")
            {
                Console.WriteLine("Please enter your customer ID");
                var custID = int.Parse(Console.ReadLine());
                var customer = Customers.filterCust(custID);

                Console.WriteLine("Please enter overdraft amount");
                int overdraftAmount = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter ballance");
                int ballance = int.Parse(Console.ReadLine());

                customer.addAccount(overdraftAmount, ballance);
            }
            else
            {
                Console.WriteLine("Please enter either 'View' or 'Add'");
                this.route();
            }
        }

        public void displayAccounts(Customer customer)
        {
            if (customer.getAccounts().Count > 1)
            {
                Console.WriteLine($"Please enter {customer.custName}'s account number");
                var accountNo = int.Parse(Console.ReadLine());
                var account = customer.filterAccount(accountNo);
                Console.WriteLine("");
                Console.WriteLine(account);
            }
            else
            {
                var account = customer.getAccounts();
                Console.WriteLine("");
                Console.WriteLine(account);
            }
        }
    }
}
