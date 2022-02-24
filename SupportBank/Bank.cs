namespace SupportBank
{
    public class Bank
    {
        public List<Transaction> Transactions  { get; set; }
        public Bank (List<Transaction> transactions)
        {
            Transactions = transactions;
        }
        public List<string> BuildAccountHolders(List<Transaction> bank)
        {
            List<AccountHolders> holders = new List<AccountHolders>();
            //Loop through all Transaction objects
            for (int i = 0; i <= bank.Count(); i++) 
            {
                
                if (holders.Any(holder => holder.Names == bank[i].FromPerson))
                {
                    holders.Total += bank[i].Amount;
                } else 
                {
                    holders.Add(bank[i].FromPerson, bank[i].Amount);
                }
                
                
                if (holders.Any(holder => holder.Names == bank[i].ToPerson))
                {
                    holders.Total -= bank[i].Amount;
                }
                else
                {
                    holders.Add(bank[i].ToPerson);
                    holders.Total -= bank[i].Amount;
                }
                
            }
            return holders;
        }
    }
}