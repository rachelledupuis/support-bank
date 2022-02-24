namespace SupportBank
{
    public class Account
    {
        public string Name { get; set; }
        public Account (string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Account: {Name}";
        }
    }
}

