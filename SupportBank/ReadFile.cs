using System;
using System.IO;

namespace SupportBank
{
    public class ReadFile
    {
        public Bank Read()
        {
            Bank bank = new Bank();
            List<Account> holders = new List<Account>();
            
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("./../Transactions2014.csv"))
                {
                    
                    string? line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    string? headerLine = sr.ReadLine();
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(',');

                        if (holders.Any(holder => holder.Name == values[1]))
                        {
                            holders.Add(new Account(values[1]));
                        }
                        
                        if (holders.Any(holder => holder.Name == values[2]))
                        {
                            holders.Add(new Account(values[2]));
                        }

                        Account from = holders.Find(account => account.Name == values[1]);
                        Account to = holders.Find(account => account.Name == values[2]);

                        bank.Transactions.Add(new Transaction(
                            DateTime.Parse(values[0]), 
                            from, 
                            to, 
                            values[3], 
                            Convert.ToDecimal(values[4])
                        ));   
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