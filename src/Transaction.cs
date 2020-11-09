using System;
namespace src
{
    public class Transaction
    {

        public int transId { get; private set; }
        public string transName { get; private set; }
        public int transAmount { get; private set; }
        public DateTime transDate { get; private set; }
        public Boolean debit { get; private set; }
        public int remainingBallance { get; private set; }

        public Transaction(int transId, string transName, int transAmount,Boolean debit, int remainingBallance)
        {
            this.transId = transId;
            this.transName = transName;
            this.transAmount = transAmount;
            this.transDate = DateTime.Now;
            this.debit = debit;
            this.remainingBallance = remainingBallance;

        }

        public override string ToString()
        {
            return $"TransID: {this.transId}{System.Environment.NewLine}Name: {this.transName}{System.Environment.NewLine}Amount: {this.transAmount} {System.Environment.NewLine}Debit?: {debit}{System.Environment.NewLine}Date: {transDate}{System.Environment.NewLine}Remaining Ballance: {remainingBallance}{System.Environment.NewLine}";
        }
    }
}
