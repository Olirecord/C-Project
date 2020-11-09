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
        Terminal terminal = new Terminal();

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

        public override string ToString()
        {
            return $"Name: {this.custName} ID: {this.custId} MemberSince: {this.dateJoined}";
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

        public void addAccount( int overdraftAmount, int ballance)
        {
            int accNo = account.Count +1;
            Account Account = new Account(accNo, custName, custId, overdraftAmount,ballance );
            account.Add(Account);
            terminal.printStatement($"account added for {custName} - account number is {accNo}");
        }
    }
}
