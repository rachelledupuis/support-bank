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
public Transaction CastToUiTransaction(InputTransaction row)
        {
            List<Account> holders = new List<Account>();
            if (!holders.Any(holder => holder.Name == row.FromAccount))
                {
                    holders.Add(new Account(row.FromAccount));
                }
                
                if (!holders.Any(holder => holder.Name == row.ToAccount))
                {
                    holders.Add(new Account(row.ToAccount));
                }

                Account from = holders.Find(account => account.Name == row.FromAccount);
                Account to = holders.Find(account => account.Name == row.ToAccount);

                Transaction UiTransn = new Transaction(row.Date, from, to, row.Narrative, row.Amount);
                return UiTransn;
            }
        }
        public override string ToString()
        {
            return $"{Date}: £{Amount} from {FromPerson.Name} to {ToPerson.Name} for {Narrative}";
        }
    }
    
}

