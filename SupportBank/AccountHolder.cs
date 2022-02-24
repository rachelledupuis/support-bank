namespace SupportBank
{
    public class AccountHolder
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public AccountHolder (string name, decimal total)
        {
            Name = name;
            Total = total;
        }
    }
}