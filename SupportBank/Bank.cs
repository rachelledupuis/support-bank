namespace SupportBank
{
    public class Bank
    {
        public List<Transaction> Transactions  { get; set; }

        public List<Account> Accounts {
            get
            {
                List<Account> accounts = new List<Account>();

                foreach(var transaction in Transactions)
                {
                    if (!accounts.Any(account => account.Name == transaction.FromPerson.Name))
                    {
                        accounts.Add(transaction.FromPerson);
                    }

                    if (!accounts.Any(account => account.Name == transaction.ToPerson.Name))
                    {
                        accounts.Add(transaction.ToPerson);
                    }
                }

                return accounts;
            }
        }
        public Bank()
        {
            Transactions = new List<Transaction>();
        }


        public void printAllTransactions()
        {
            foreach(var transaction in Transactions)
            {
                Console.WriteLine($"{transaction.Date}: £{transaction.Amount} from {transaction.FromPerson.Name} to {transaction.ToPerson.Name} for {transaction.Narrative}");
            }
        }

         public decimal GetAccountBalance(string name)
        {
            if (!Accounts.Any(account => account.Name == name))
            {
                throw new ArgumentOutOfRangeException("The given name does not match to any account");
            }

            Account account = Accounts.Find(a => a.Name == name);
            decimal result = 0;

            foreach(var transaction in Transactions)
            {
                if (transaction.FromPerson.Name == account.Name)
                {
                    result -= transaction.Amount;
                }
                if (transaction.ToPerson.Name == account.Name)
                {
                    result += transaction.Amount;
                }
            }

            return result;
        }
    } 
}