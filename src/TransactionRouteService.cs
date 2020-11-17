using System;
using System.Collections.Generic;

namespace src
{
    public class TransactionRouteService : IRouter
    {
        readonly Customers Customers;
        Terminal terminal = new Terminal();

        public TransactionRouteService(object customers)
        {
            this.Customers = (Customers)customers;
        }

        public void route()
        {
            terminal.printStatement("Would you like to view or add a Transaction?");
            var choice1 = terminal.returnStatement();

            terminal.printStatement("Please enter your customer ID");
            var custId = int.Parse(terminal.returnStatement());
            Customer customer;

                try
                {
                    customer = Customers.filterCust(custId);
                }
                catch(UnableToLocateCustomerException e)
                {
                    Console.WriteLine("Unable To Locate Customer: {0}", e.Message);
                    route();
                }
            
            terminal.printStatement("Please enter the account number you wish to interact with");
            var accountNo = int.Parse(terminal.returnStatement());
            var account = customer.filterAccount(accountNo);

            if (choice1.ToLower() == "view")
            {
                terminal.printStatement("Would you like to view all or recent transactions?");
                var choice2 = terminal.returnStatement();

                if (choice2.ToLower() == "all")
                {
                    var transactions = account.getTransactions(10000);
                    displayTrans(transactions);
                }
                else if (choice2.ToLower() == "recent")
                {
                    terminal.printStatement("How many recent transactions would you like to view?");
                    var count = int.Parse(terminal.returnStatement());
                    var transactions = account.getTransactions(count);
                    displayTrans(transactions);
                }
                else
                {
                    terminal.printStatement("Please enter either 'All' or 'Recent'");
                    this.route();
                }
            }
            else if (choice1.ToLower() == "add")
            {
                Boolean debit = false;
                terminal.printStatement("Please enter transaction name");
                var transName = terminal.returnStatement();
                terminal.printStatement("Please enter an amount");
                var transAmount = int.Parse(terminal.returnStatement());
                terminal.printStatement("Debit or Credit?");
                var choice = terminal.returnStatement();

                if (choice.ToLower() == "debit"){debit = true;}

                try
                {
                    account.addTransaction(transName, transAmount, debit);
                }
                catch(OverdraftLimitExceededException e)
                {
                    Console.WriteLine("Overdraft Limit Exceeded: {0}", e.Message);
                }
                this.route();

            }
            else
            {
               terminal.printStatement("Please enter either 'View' or 'Add'");
                this.route();
            }

        }

            

            public void displayTrans(List<Transaction> transactions)
            {
                foreach (Transaction data in transactions)
                {
                    terminal.printStatement($"");
                    terminal.printTransaction(data);
                }
            }

        

    }
}
