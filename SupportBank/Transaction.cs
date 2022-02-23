using System;

namespace SupportBank
{
    public class Transaction
    {
        public string Date { get; set; }
        public string FromPerson { get; set; }
        public string ToPerson { get; set; }
        public string Narrative { get; set; }
        public string Amount { get; set; }

        public Transaction(string date, string fromPerson, string toPerson, string narrative, string amount)
        {
            Date = date;
            FromPerson = fromPerson;
            ToPerson = toPerson;
            Narrative = narrative;
            Amount = amount;
        }
    }
}

