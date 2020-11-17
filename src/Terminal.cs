using System;

namespace src
{
    internal class Terminal
    {
        public Terminal()
        {
        }

        public void printStatement(params string[] statements)
        {
            foreach (string statement in statements)
            {
                Console.WriteLine(statement);
            }

        }
        public void printCustomer(Customer customer)
        {
               Console.WriteLine(customer);
        }

        public void printAccount(Account account)
        {
            Console.WriteLine(account);
        }
        public void printTransaction(Transaction transaction)
        {
            Console.WriteLine(transaction);
        }


        public string returnStatement()
        {
            return Console.ReadLine();
        }
    }
}