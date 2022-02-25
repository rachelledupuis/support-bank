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
                        if (!accounts.Any(account => account.Name == transaction.FromAccount.Name))
                            {
                                accounts.Add(transaction.FromAccount);
                            }
                            
                        if (!accounts.Any(account => account.Name == transaction.ToAccount.Name))
                        {
                            accounts.Add(transaction.ToAccount);
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
                    Logger.Info($"input= {name}, Transaction FromName = {transaction.FromAccount.Name}, ToName = {transaction.ToAccount.Name}");
                    if (!Transactions.Any(transaction => transaction.FromAccount.Name == name))
                    {
                        if (!Transactions.Any(transaction => transaction.ToAccount.Name == name))
                        {
                            throw new ArgumentOutOfRangeException("The given name does not match to any account");
                        }
                    }
                    if (transaction.FromAccount.Name == name)
                    {
                        Console.WriteLine($"{transaction.Date.ToString("dd/MM/yyyy")}: £{transaction.Amount} owed to {transaction.ToAccount.Name} for {transaction.Narrative}");
                    }
                    if (transaction.ToAccount.Name == name)
                    {
                        Console.WriteLine($"{transaction.Date.ToString("dd/MM/yyyy")}: £{transaction.Amount} owed by {transaction.FromAccount.Name} for {transaction.Narrative}");
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
                    if (transaction.FromAccount.Name == name)
                    {
                        result -= transaction.Amount;
                    }
                    if (transaction.ToAccount.Name == name)
                    {
                        result += transaction.Amount;
                    }
                }
                Console.WriteLine($"{name}: {result}");
            }
        }
    } 
}