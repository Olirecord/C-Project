using System;
using System.Collections.Generic;


namespace src
{
    class Service
    {

        Customers customers = new Customers();
        Terminal terminal = new Terminal();
        IDictionary<string, IRouter> dictionaryRoute = new Dictionary<string, IRouter>();


        private string userMainRoute= "";
        
        

        public Service()
        {
            preloadData();
            dictionaryRoute.Add("customer",  new CustomerRouteService(this.customers));
            dictionaryRoute.Add("account",   new AccountRouteService(this.customers));
            dictionaryRoute.Add("transaction", new TransactionRouteService(this.customers));
            mainMenu(true);

        }


        public void mainMenu(Boolean loop)
        {
            while(loop)
            {
                terminal.printStatement("Welcome to Olis Bank, Would you like to view or add a Customer, Account or Transaction?");
                terminal.printStatement(" ");
                userMainRoute = terminal.returnStatement();
                router(userMainRoute);
            }
            
        }


        public void router(string route)
        {
            var choice = dictionaryRoute[route.ToLower()];
            choice.route();

        }

        public void preloadData()
        {
            customers.addCustomer("Oli");
            var customer = customers.getCustList()[0];
            customer.addAccount(100, 100);
            customer.addAccount(500, 500);
            var accounts = customer.getAccounts();

            foreach(Account account in accounts)
            {
                account.addTransaction("Fuel",30,true);
                account.addTransaction("SickPay", 100, false);
            }
            
        }

    }
}

 

