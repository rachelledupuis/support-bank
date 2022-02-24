using System;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile transactionsCsv = new ReadFile();
            Bank supportBank = transactionsCsv.Read();
            Console.WriteLine(supportBank.Transactions[0].FromPerson);
        }
    }
}