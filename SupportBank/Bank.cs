using NLog;
namespace SupportBank
{
    public class Bank
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public List<Transaction> Transactions  { get; set; }

        public List<Account> Accounts {
            get
            {
                
                List<Account> accounts = new List<Account>();
                try
                { 
                    //Logger.Info("Hello world");
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
                 
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "transaction: line 32");
                }
            return accounts;
            }
        }
        public Bank()
        {
            Transactions = new List<Transaction>();
        }


        public void PrintAllTransactions(string name)
        {
            try 
            {
                foreach(var transaction in Transactions)
                {
                    //Logger.Info($"input= {name}, Transaction FromName = {transaction.FromPerson.Name}, ToName = {transaction.ToPerson.Name}");
                    if (!Transactions.Any(transaction => transaction.FromPerson.Name == name))
                    {
                        if (!Transactions.Any(transaction => transaction.ToPerson.Name == name))
                        {
                            throw new ArgumentOutOfRangeException("The given name does not match to any account");
                        }
                    }
                    if (transaction.FromPerson.Name == name)
                    {
                        Console.WriteLine($"{transaction.Date.ToString("dd/MM/yyyy")}: £{transaction.Amount} owed to {transaction.ToPerson.Name} for {transaction.Narrative}");
                    }
                    if (transaction.ToPerson.Name == name)
                    {
                        Console.WriteLine($"{transaction.Date.ToString("dd/MM/yyyy")}: £{transaction.Amount} owed by {transaction.FromPerson.Name} for {transaction.Narrative}");
                    }
                }
            }
            catch (Exception)
            {
                Logger.Error($"input= {name}");
                throw new ArgumentOutOfRangeException("The given name does not match to any account");
            }
        }

        public void GetAccountBalance()
        {
            foreach (var account in Accounts)
            {
                var name = account.Name;
                decimal result = 0;
            
                foreach(var transaction in Transactions)
                {
                    if (transaction.FromPerson.Name == name)
                    {
                        result -= transaction.Amount;
                    }
                    if (transaction.ToPerson.Name == name)
                    {
                        result += transaction.Amount;
                    }
                }
                Console.WriteLine($"{name}: {result}");
            }
        }
    } 
}