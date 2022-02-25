using System;
using System.IO;
using System.Text.Json;

namespace SupportBank
{
    public class ReadJsonFile : IReadable
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();       
        public Bank Read(string filePath)
        {
            Bank bank = new Bank();
            List<Account> holders = new List<Account>();
            
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                //using (StreamReader r = new StreamReader(filePath))
                {
                    //string json = r.ReadToEnd();
                    //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                    string jsonString = File.ReadAllText(filePath);
                    var lines = JsonSerializer.Deserialize<List<Transaction>>(jsonString);
                    //dynamic array = JsonConvert.DeserializeObject(json);
                    //Transaction myDeserializedClass = JsonConvert.DeserializeObject(myJsonResponse); 
                    
                    //Transaction transaction = JsonSerializer.Deserialize<Transaction>(jsonString)!;
                    foreach(var transaction in lines)
                    {
                        if (!holders.Any(holder => holder.Name == transaction.FromAccount.Name))
                        {
                            holders.Add(new Account(transaction.FromAccount.Name));
                        }
                        
                        if (!holders.Any(holder => holder.Name == transaction.ToAccount.Name))
                        {
                            holders.Add(new Account(transaction.ToAccount.Name));
                        }

                        Account from = holders.Find(account => account.Name == transaction.FromAccount.Name);
                        Account to = holders.Find(account => account.Name == transaction.ToAccount.Name);

                        try {
                            bank.Transactions.Add(new Transaction(
                            transaction.Date, 
                            transaction.FromAccount, 
                            transaction.ToAccount, 
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