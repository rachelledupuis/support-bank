using System;

namespace SupportBank
{
    public class TransactionJsonFile
    {
        public string Date { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public TransactionJsonFile(string date, string fromPerson, string toPerson, string narrative, decimal amount)
        {
            Date = date;
            FromAccount = fromPerson;
            ToAccount = toPerson;
            Narrative = narrative;
            Amount = amount;
        }
        public Transaction ConvertJsonTransaction()
        {
            Account from = new Account(FromAccount);
            Account to = new Account(ToAccount);
            Transaction transactionFromJson = new Transaction(DateTime.Parse(Date), from, to, Narrative, Amount);
            return transactionFromJson;
        }
    }
}

