using System;
using System.Collections.Generic;

namespace src
{
    public class Customer
    {
        public int custId;
        public string custName;
        public DateTime dateJoined;

        private readonly List<Account> account = new List<Account>();

        public Customer(int custId,string custName)
        {
            this.custId = custId;
            this.custName = custName;
            this.dateJoined = DateTime.Now;

            Account Account = new Account(1, custName, custId, 100, 100);
            account.Add(Account);
            Account Account2 = new Account(2, custName, custId, 100, 500);
            account.Add(Account2);
        }

        public Account filterAccount(int accountNo)
        {
            var reponse = account.Find(r => r.accountNo == accountNo);
            return reponse;
        }

        public List<Account> getAccounts()
        {
            return account;
        }

        public void addAccount(int accountNo, string nameOnAcc, int custId, int overdraftAmount, int ballance)
        {

            Account Account = new Account(accountNo, nameOnAcc, custId, overdraftAmount,ballance );
            account.Add(Account);
            Console.WriteLine($"account added for {nameOnAcc} - account number is {accountNo}");


        }
    }
}
