namespace SupportBank
{
    public class Account
    {
        public string Name { get; set; }
        public double Sum { get; set; }

        public Account (string name, double sum)
        {
            Name = name;
            Sum = sum;
        }
        public List<string> PersonName = new List<string>();
    }
}

