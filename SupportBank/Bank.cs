namespace SupportBank
{
    public class Bank
    {
        public List<Transaction> Transactions  { get; set; }
        public Bank (List<Transaction> transactions)
        {
            Transactions = transactions;
        }
        public void BuildBank()
        {
            
        }
    }
}