using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace src
{
    class Service
    {

        Customers Customers = new Customers();
        Terminal terminal = new Terminal();
        IDictionary<string, IRouter> dictionaryRoute = new Dictionary<string, IRouter>();


        private string userMainRoute= "";
        
        

        public Service()
        {
            dictionaryRoute.Add("customer",  new CustomerRouteService(this.Customers));
            dictionaryRoute.Add("account",   new AccountRouteService(this.Customers));
            dictionaryRoute.Add("transaction", new TransactionRouteService(this.Customers));
            mainMenu(true);
        }


        public void mainMenu(Boolean loop)
        {
            while(loop == true)
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

    }
}

 

