using System;
using System.IO;

namespace SupportBank
{
    public class ReadCsvFile : IReadable
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();       
        public List<CsvTransaction> Read(string filePath)
        {
            // Bank bank = new Bank();
            // List<Account> holders = new List<Account>();
            List<CsvTransaction> csvInput = new List<CsvTransaction>();
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filePath))
                {
                    
                    string? line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    string? headerLine = sr.ReadLine();
                    
                    int lineNo = 2;
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        //Logger.Info($"Line no: {lineNo}: {line}");
                        var values = line.Split(',');

                        

                        try {
                            csvInput.Add(new CsvTransaction(
                            DateTime.Parse(values[0]), 
                            values[1], 
                            values[2], 
                            values[3], 
                            Convert.ToDecimal(values[4])
                            ));  
                        }
                        catch (FormatException)
                        {
                            Logger.Error($"CSV:Format Exception on Line: {line}");
                        }
                         
                        
                        lineNo++;
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return csvInput;
        }
    }
}