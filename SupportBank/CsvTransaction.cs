using System;

namespace SupportBank
{
    public class InputTransaction
    {
        public DateTime Date { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public InputTransaction(DateTime date, string fromAccount, string toAccount, string narrative, decimal amount)
        {
            Date = date;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Narrative = narrative;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date}: £{Amount} from {FromPerson} to {ToPerson} for {Narrative}";
        }
    }
    
}

