using System;
using NLog;

namespace SupportBank
{
    class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"C:\Training\support-bank\SupportBank\log.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
                        
            // Rules for mapping loggers to targets            
            //config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
                        
            // Apply config           
            NLog.LogManager.Configuration = config;
        
            string goodFile = @"C:\Training\support-bank\Transactions2014.csv";
            string dodgyFile = @"C:\Training\support-bank\DodgyTransactions2015.csv";
            
            //ReadCsvFile transactionsCsv = new ReadCsvFile();
            //Bank supportBank = transactionsCsv.Read(dodgyFileA);

            string jsonFile = @"C:\Training\support-bank\Transactions2013.json";
            ReadJsonFile transactionsJson = new ReadJsonFile();
            Bank supportBank = transactionsJson.Read(jsonFile);

            try 
            {
                if (args[0].ToLower() != "list")
                {
                    return;
                }
                if (args[1].ToLower() == "all")
                {
                    supportBank.GetAccountBalance();
                    return;
                } else {
                    if (args[2] != "")
                    {    
                        string name = args[1] + " " + args[2];
                        supportBank.PrintAllTransactions(name);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Logger.Error("No command entered. Please enter list all or list followed by a name");
                throw;
            }
        }
    }
}