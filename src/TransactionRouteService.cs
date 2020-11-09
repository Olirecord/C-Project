using System;
using System.Collections.Generic;

namespace src
{
    public class TransactionRouteService : IRouter
    {
        readonly Customers Customers;

        public TransactionRouteService(object customers)
        {
            this.Customers = (Customers)customers;
        }

        public void route()
        {
            Console.WriteLine("Would you like to view or add a Transaction?");
            var choice1 = Console.ReadLine();

            Console.WriteLine("Please enter your customer ID");
            var custId = int.Parse(Console.ReadLine());
            var customer = Customers.filterCust(custId);
            Console.WriteLine("Please enter the account number you wish to view transaction history on");
            var accountNo = int.Parse(Console.ReadLine());
            var account = customer.filterAccount(accountNo);

            if (choice1.ToLower() == "view")
            {
                Console.WriteLine("Would you like to view all or recent transactions?");
                var choice2 = Console.ReadLine();

                if (choice2.ToLower() == "all")
                {
                    var transactions = account.getTransactions(10000);
                    displayTrans(transactions);
                }
                else if (choice2.ToLower() == "recent")
                {
                    Console.WriteLine("How many recent transactions would you like to view?");
                    var count = int.Parse(Console.ReadLine());
                    var transactions = account.getTransactions(count);
                    displayTrans(transactions);
                }
                else
                {
                    Console.WriteLine("Please enter either 'All' or 'Recent'");
                    this.route();
                }
            }
            else if (choice1.ToLower() == "add")
            {
                Boolean debit = false;
                Console.WriteLine("Please enter transaction name");
                var transName = Console.ReadLine();
                Console.WriteLine("Please enter an amount");
                var transAmount = int.Parse(Console.ReadLine());
                Console.WriteLine("Debit or Credit?");
                var choice = Console.ReadLine();

                if (choice.ToLower() == "debit") { debit = true; }

                Console.WriteLine(account.addTransaction(transName, transAmount, debit));
                this.route();

            }
            else
            {
                Console.WriteLine("Please enter either 'View' or 'Add'");
                this.route();
            }

        }


            public void displayTrans(List<Transaction> transactions)
            {
                foreach (Transaction data in transactions)
                {
                    Console.WriteLine($"");
                    Console.WriteLine(data);
                }
            }

        
    }
}
