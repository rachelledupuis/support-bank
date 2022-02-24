namespace SupportBank
{
    public class AccountHolders
    {
        public List<string> Names { get; set; }
        public decimal Total { get; set; }
        public AccountHolders (List<string> names, decimal total)
        {
            Names = names;
            Total = total;
        }
    }
}