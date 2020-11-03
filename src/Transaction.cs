using System;
namespace src
{
    public class Transaction
    {

        public int transId { get; private set; }
        public string transName;
        public int transAmount;
        public DateTime transDate;
        public Boolean debit;
        public int remainingBallance;

        public Transaction(int transId, string transName, int transAmount,Boolean debit, int remainingBallance)
        {
            this.transId = transId;
            this.transName = transName;
            this.transAmount = transAmount;
            this.transDate = DateTime.Now;
            this.debit = debit;
            this.remainingBallance = remainingBallance;

        }
    }
}
