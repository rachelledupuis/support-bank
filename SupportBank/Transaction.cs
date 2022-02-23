using System;

namespace SupportBank
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string FromPerson { get; set; }
        public string ToPerson { get; set; }
        public string Narrative { get; set; }
        public double Amount { get; set; }

        public Transaction(DateTime date, string fromPerson, string toPerson, string narrative, double amount)
        {
            Date = date;
            FromPerson = fromPerson;
            ToPerson = toPerson;
            Narrative = narrative;
            Amount = amount;
        }
    }
}

