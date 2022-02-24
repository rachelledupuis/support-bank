using System;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile test = new ReadFile();
            // test.Read();
            Bank supportBank = new Bank(test.Read());
            Console.WriteLine(supportBank.Transactions[0].FromPerson);
            List<AccountHolder> accountHolders = new List<AccountHolder>(supportBank.BuildAccountHolders(supportBank));
            
        }
    }
}