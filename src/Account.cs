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

            
            Transaction transaction1 = new Transaction(1,"Fuel", 30, true, this.ballance-30);
            this.ballance = this.ballance - 30;
            transactions.Add(transaction1);
            Transaction transaction2 = new Transaction(2, "SickPay", 10, false, this.ballance + 10);
            transactions.Add(transaction2);
            this.ballance = this.ballance + 10;
        }

        public override string ToString()
        {
            return $"AccNo: {this.accountNo} Ballance: {this.ballance} Overdraft: {this.overdraftAmount}"; 
        }

        public string addTrans( string transName, int transAmount, Boolean debit,int remainingBallance)
        {
            int transID = transactions.Count + 1;
            Transaction transaction = new Transaction(transID, transName, transAmount, debit, remainingBallance);
            transactions.Add(transaction);
            var confirmation = $"Your transaction for {transName} for £{transAmount} has been taken from your ballance";
            this.ballance = remainingBallance;
            return confirmation;
        }

        public List<Transaction> getTransactions(int noOfTrans)
        {
            return transactions.Take(noOfTrans).ToList();
        }

        public int calcBallance(int transAmount)
        {
            int remainingBallance;
            if (this.ballance < 0)
            {
                remainingBallance = (this.ballance + (transAmount * -1));
                return remainingBallance;
            }
            else
            {
                remainingBallance = this.ballance - transAmount;
                return remainingBallance;
            }
        }

        public string addTransaction(string transName, int transAmount, Boolean debit)
        {
            var remainingBallance = calcBallance(transAmount);

            if (debit == true)
            {
                if (remainingBallance < 0 && remainingBallance >= (this.overdraftAmount * -1))
                {
                    terminal.printStatement("This transaction will take you into your overdraft");
                    return addTrans(transName, transAmount, debit, remainingBallance);
                }
                else if (remainingBallance < (this.overdraftAmount * -1))
                {
                    terminal.printStatement("This transaction would take you over your agreed overdraft, please choose a lower amount");
                    var confirmation = "";
                    return confirmation;
                }
                else
                {
                    return addTrans(transName, transAmount, debit, remainingBallance);
                }
            }
            else
            {

                return addTrans(transName, transAmount, debit, (this.ballance + transAmount));
            }
        }


    }
}


