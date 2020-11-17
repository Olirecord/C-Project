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

        public Account addAccount( int overdraftAmount, int ballance)
        {
            int accNo = account.Count +1;
            Account Account = new Account(accNo, custName, custId, overdraftAmount,ballance );
            account.Add(Account);
            return Account;
        }
    }
}
