using System;
using System.IO;
using Newtonsoft.Json;

namespace SupportBank
{
    public class ReadXmlFile : IReadable
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();       
        public Bank Read(string filePath)
        {
            Bank bank = new Bank();
            List<Account> holders = new List<Account>();
            
            try
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    dynamic jsonArray = JsonConvert.DeserializeObject<List<TransactionJsonFile>>(json); 
                    
                    foreach(var transaction in jsonArray)
                    {
                        if (!holders.Any(holder => holder.Name == transaction.FromAccount))
                        {
                            holders.Add(new Account(transaction.FromAccount));
                        }
                        
                        if (!holders.Any(holder => holder.Name == transaction.ToAccount))
                        {
                            holders.Add(new Account(transaction.ToAccount));
                        }

                        Account from = holders.Find(account => account.Name == transaction.FromAccount);
                        Account to = holders.Find(account => account.Name == transaction.ToAccount);

                        try {
                           bank.Transactions.Add(new Transaction(
                                DateTime.Parse(transaction.Date), 
                                from, 
                                to, 
                                transaction.Narrative, 
                                transaction.Amount
                                ));
                        }
                        catch (FormatException)
                        {
                            Logger.Error($"CSV:Format Exception on Line:");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return bank;
        }
    }
}