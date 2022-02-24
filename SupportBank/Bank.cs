namespace SupportBank
{
    public class Bank
    {
        public List<Transaction> Transactions  { get; set; }
        public Bank (List<Transaction> transactions)
        {
            Transactions = transactions;
        }
        public List<AccountHolder> BuildAccountHolders(List<Transaction> bank)
        {
            List<AccountHolder> holders = new List<AccountHolder>();
            //Loop through all Transaction objects
            for (int i = 0; i <= bank.Count(); i++) 
            {
                
                if (holders.Any(holder => holder.Name == bank[i].FromPerson))
               
                {
                    holders.Single(x => x.Name == bank[i].FromPerson).Total = Convert.ToDecimal(bank[i].Amount);
                    
                } else 
                {
                    AccountHolder account = new AccountHolder(bank[i].FromPerson, Convert.ToDecimal(bank[i].Amount));
                    holders.Add(account);
                }
                
                
                if (holders.Any(holder => holder.Name == bank[i].ToPerson))
                {
                    holders.Single(x => x.Name == bank[i].ToPerson).Total = (Convert.ToDecimal(bank[i].Amount) * -1);
                }
                else
                {
                    AccountHolder account = new AccountHolder(bank[i].ToPerson, (Convert.ToDecimal(bank[i].Amount)*-1));
                    holders.Add(account);
                }
                
            }
            return holders;
        }
        // public void PrintAccounts(List<AccountHolder> holders)
        // {
        //     foreach 
        //     Console.WriteLine($"{holders.N")
        // }
    }
}