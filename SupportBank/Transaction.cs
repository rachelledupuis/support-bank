using System;

namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateTime date, Account fromPerson, Account toPerson, string narrative, decimal amount)
        {
            Date = date;
            FromAccount = fromPerson;
            ToAccount = toPerson;
            Narrative = narrative;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date}: £{Amount} from {FromAccount.Name} to {ToAccount.Name} for {Narrative}";
        }
    }
    
}

