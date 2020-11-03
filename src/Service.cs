using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace src
{
    class Service
    {

        Customers Customers = new Customers();
        

        private string userMainRoute= "";
        private string userSubRoute = "";
        

        public Service()
        {
            mainMenu();

        }


        public void mainMenu()
        {
            Console.WriteLine("Welcome to Olis Bank, Would you like to view or add a Customer, Account or Transaction?");
            Console.WriteLine("");
            userMainRoute = Console.ReadLine();
            router(userMainRoute);
        }


        public void router(string route)
        {
            if(route.ToLower() == "customer")
            {
                Console.WriteLine("Would you like to view or add a Customer?");
                userSubRoute = Console.ReadLine();
                custRoute(userSubRoute);

            }
            else if (route.ToLower() == "account")
            {
                Console.WriteLine("Would you like to view or add a Account?");
                userSubRoute = Console.ReadLine();
                accRoute(userSubRoute);
            }
            else if(route.ToLower()== "transaction")
            {
                Console.WriteLine("Would you like to view or add a Transaction?");
                userSubRoute = Console.ReadLine();
                transRoute(userSubRoute);
            }
            else
            {
                Console.WriteLine("Please enter either 'Customer', 'Account' or 'Transaction");
                mainMenu();
            }
        }



        public void accRoute(string route)
        {

            if (route.ToLower() == "view")
            {

                Console.WriteLine("Please enter your customer ID");
                int custId = int.Parse(Console.ReadLine());
                var customer = Customers.filterCust(custId);

                if(customer.getAccounts().Count > 1)
                {
                    Console.WriteLine($"Please enter {customer.custName}'s account number");
                    var accountNo = int.Parse(Console.ReadLine());
                    var account = customer.filterAccount(accountNo);
                    Console.WriteLine("");
                    Console.WriteLine($"Account Number: {account.accountNo}");
                    Console.WriteLine($"Ballance: {account.ballance}");
                    Console.WriteLine($"Overdraft Amount: {account.overdraftAmount}");
                    mainMenu();

                }
                else
                {
                    var account = customer.getAccounts();
                    Console.WriteLine("");
                    Console.WriteLine($"Account Number: {account[0].accountNo}");
                    Console.WriteLine($"Ballance: {account[0].ballance}");
                    Console.WriteLine($"Overdraft Amount: {account[0].overdraftAmount}");
                    mainMenu();
                }

            }
            else if (route.ToLower() == "add")
            {
                Console.WriteLine("Please enter your customer ID");
                var custID = int.Parse(Console.ReadLine());
                var customer = Customers.filterCust(custID);

                Console.WriteLine("Please enter overdraft amount");
                int overdraftAmount = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter ballance");
                int ballance = int.Parse(Console.ReadLine());

                if(customer.getAccounts().Count > 1)
                {
                    customer.addAccount(customer.getAccounts().Count+1, customer.custName, customer.custId, overdraftAmount, ballance);
                }
                else
                {
                    customer.addAccount(1, customer.custName, customer.custId, overdraftAmount, ballance);
                }
                mainMenu();

            }
            else
            {
                Console.WriteLine("Please enter either 'View' or 'Add'");
                router(userMainRoute);
            }


        }
        public void custRoute(string route)
        {
            
            if (route.ToLower() == "view")
            {
                
                Console.WriteLine("Please enter the customer ID");
                var custId = int.Parse(Console.ReadLine());
                var customer = Customers.filterCust(custId);
                Console.WriteLine("");
                Console.WriteLine($"Name: {customer.custName}");
                Console.WriteLine($"Id: {customer.custId}");
                Console.WriteLine($"Date joined: { customer.dateJoined}");

                mainMenu();
            }
            else if (route.ToLower() == "add")
            {
                Console.WriteLine("Please enter the name of the customer you wish to add");
                var custToAdd = Console.ReadLine();
                Console.WriteLine(Customers.addCustomer(custToAdd));
                mainMenu();

            }
            else {
                Console.WriteLine("Please enter either 'View' or 'Add'");
                router(userMainRoute);
            }

            
        }

        public void transRoute(string route)
        {

            Console.WriteLine("Please enter your customer ID");
            var custId = int.Parse(Console.ReadLine());
            var customer = Customers.filterCust(custId);
            Console.WriteLine("Please enter the account number you wish to view transaction history on");
            var accountNo = int.Parse(Console.ReadLine());
            var account = customer.filterAccount(accountNo);
            var transactions = account.getTransactions();

            if (route.ToLower() == "view")
            {
                Console.WriteLine("Would you like to view all or recent transactions?");
                var choice = Console.ReadLine();

                if (choice.ToLower() == "all")
                {
                    foreach (Transaction data in transactions)
                    {
                        Console.WriteLine($"");
                        Console.WriteLine($"Transaction ID: {data.transId}");
                        Console.WriteLine($"For: {data.transName}");
                        Console.WriteLine($"Amount: {data.transAmount}");
                        Console.WriteLine($"Debit?(Credit if false): {data.debit}");
                        Console.WriteLine($"Date: {data.transDate}");
                        Console.WriteLine($"Remaining ballance: {data.remainingBallance}");
                    }
                    mainMenu();

                }
                else if (choice.ToLower() == "recent")
                {
                    Console.WriteLine("How many recent transactions would you like to view?");
                    var count = int.Parse(Console.ReadLine());
                    var recentTrans = account.recentTransactions(count);
                    foreach (Transaction data in recentTrans)
                    {
                        Console.WriteLine($"");
                        Console.WriteLine($"Transaction ID: {data.transId}");
                        Console.WriteLine($"For: {data.transName}");
                        Console.WriteLine($"Amount: {data.transAmount}");
                        Console.WriteLine($"Debit?(Credit if false): {data.debit}");
                        Console.WriteLine($"Date: {data.transDate}");
                        Console.WriteLine($"Remaining ballance: {data.remainingBallance}");
                    }
                    mainMenu();
                }
                else
                {
                    Console.WriteLine("Please enter either 'All' or 'Recent'");
                    router(userSubRoute);
                }
                

                mainMenu();
            }
            else if (route.ToLower() == "add")
            {
                Boolean debit = false;
                var transId = transactions.Count + 1;
                Console.WriteLine("Please enter transaction name");
                var transName = Console.ReadLine();
                Console.WriteLine("Please enter an amount");
                var transAmount = int.Parse(Console.ReadLine());
                Console.WriteLine("Debit or Credit?");
                var choice = Console.ReadLine();
                      
                    if (choice.ToLower() == "debit"){debit = true;}
                    else{ Console.WriteLine("Please enter either Debit or Credit"); }


                Console.WriteLine(account.addTransaction(transId,transName,transAmount,debit));
                router("transaction");

            }
            else
            {
                Console.WriteLine("Please enter either 'View' or 'Add'");
                router(userMainRoute);
            }
        }

        

        


    }
}

 

