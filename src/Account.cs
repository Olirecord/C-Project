using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace src
{
    public class Account
    {
        public int accountNo { get; private set; }
        public string nameOnAcc { get; private set; }
        public int custId { get; private set; }
        public int overdraftAmount { get; private set; }
        public int ballance { get; private set; }

        private readonly List<Transaction> transactions = new List<Transaction>();
        Terminal terminal = new Terminal();

        public Account(int accountNo, string nameOnAcc, int custId, int overdraftAmount, int ballance)
        {
            this.accountNo = accountNo;
            this.nameOnAcc = nameOnAcc;
            this.custId = custId;
            this.overdraftAmount = overdraftAmount;
            this.ballance = ballance;

        }

        public override string ToString()
        {
            return $"AccNo: {this.accountNo} Ballance: {this.ballance} Overdraft: {this.overdraftAmount}"; 
        }

        public string addTransaction( string transName, int transAmount, Boolean debit)
        {
            int remainingBallance;

            if (debit == true && checkOverdraft(transAmount) == false)
            {
                throw (new OverdraftLimitExceededException("This transaction would take you over your agreed overdraft, please choose a lower amount"));
            }
            else if (debit == true && checkOverdraft(transAmount) == true)
            {
                remainingBallance = this.ballance - transAmount;
            }
            else
            {
                remainingBallance = this.ballance + transAmount;
            }

            int transID = transactions.Count + 1;
            Transaction transaction = new Transaction(transID, transName, transAmount, debit, remainingBallance);
            transactions.Add(transaction);
            var confirmation = "Transaction Succesfull";
            this.ballance = remainingBallance;
            return confirmation;
        }

        public List<Transaction> getTransactions(int noOfTrans)
        {
            return transactions.Take(noOfTrans).ToList();
        }


        public Boolean checkOverdraft(int transAmount)
        {
            var remainingBallance = this.ballance - transAmount;

            if (remainingBallance < (this.overdraftAmount * -1))
            { 
                return false;
            }

            if (remainingBallance < 0 && remainingBallance >= (this.overdraftAmount * -1))
            {
                terminal.printStatement("This transaction will take you into your overdraft");
            }

            return true;
        }

    }
}


