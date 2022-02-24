namespace SupportBank
{
    public class Bank
    {
        public List<Transaction> Transactions  { get; set; }
        public Bank()
        {
            Transactions = new List<Transaction>();
        }

        public void printAllTransactions()
        {
            foreach(var transaction in Transactions)
            {
                Console.WriteLine($"{transaction.Date}: £{transaction.Amount} from {transaction.FromPerson} to {transaction.ToPerson} for {transaction.Narrative}");
            }
        }
    } 
}