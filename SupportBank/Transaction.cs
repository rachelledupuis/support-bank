using System;

namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public Account FromPerson { get; set; }
        public Account ToPerson { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateTime date, Account fromPerson, Account toPerson, string narrative, decimal amount)
        {
            Date = date;
            FromPerson = fromPerson;
            ToPerson = toPerson;
            Narrative = narrative;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Date}: £{Amount} from {FromPerson.Name} to {ToPerson.Name} for {Narrative}";
        }
    }
    
}

