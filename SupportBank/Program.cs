using System;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile transactionsCsv = new ReadFile();
            Bank supportBank = transactionsCsv.Read("./../Transactions2014.csv");
            supportBank.printAllTransactions();
        }
    }
}