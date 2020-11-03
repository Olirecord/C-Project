using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace src
{
    public class Account
    {
        public int accountNo { get;}
        public string nameOnAcc { get;}
        public int custId { get; set; }
        public int overdraftAmount { get;}
        public int ballance { get; set; }

        private readonly List<Transaction> transactions = new List<Transaction>();

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




        public string addTransaction(int transId, string transName, int transAmount, Boolean debit)
        {
            
            var remainingBallance = calcBallance(transAmount);
            var confirmation = $"Your credit from {transName} for £{transAmount} has been added to your ballance";

            if (debit == true)
            {
                if(remainingBallance < 0 && remainingBallance >= (overdraftAmount * -1))
                {   
                    Console.WriteLine("This transaction will take you into your overdraft");
                    Transaction transaction = new Transaction(transId, transName, transAmount, debit, remainingBallance);
                    transactions.Add(transaction);
                    confirmation = $"Your debit for {transName} for £{transAmount} has been taken from your ballance";
                    this.ballance = remainingBallance;
                    return confirmation;
                }
                else if(remainingBallance < (overdraftAmount * -1))
                {
                    Console.WriteLine("This transaction would take you over your agreed overdraft, please choose a lower amount");
                    confirmation = "";
                    return confirmation;
                }
                else
                {
                    Transaction transaction = new Transaction(transId, transName, transAmount, debit, remainingBallance);
                    transactions.Add(transaction);
                    this.ballance = remainingBallance;
                    confirmation = $"Your debit for {transName} for £{transAmount} has been taken from your ballance";
                    return confirmation;
                }
               
            }
            else
            {
                Transaction transaction = new Transaction(transId, transName, transAmount, debit, (this.ballance+transAmount));
                transactions.Add(transaction);
                this.ballance = this.ballance + transAmount;   
                return confirmation;
            }
            
        }

        public List<Transaction> recentTransactions(int noOfTrans)
        {
            List<Transaction> tempTrans = new List<Transaction>();

            if(noOfTrans > transactions.Count)
            {
                noOfTrans = transactions.Count - 1;
                for (int count = 0; count <= noOfTrans; count += 1)
                {
                    tempTrans.Add(transactions[count]);
                }
                return tempTrans;
            }
            else
            {
                for (int count = 0; count< noOfTrans; count += 1)
                {
                    tempTrans.Add(transactions[count]);
                }
                return tempTrans;
            }
            
        }

        public List<Transaction> getTransactions()
        {
            return transactions ;
        }

        
    }
}


