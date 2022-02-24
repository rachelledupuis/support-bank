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
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"C:\Training\support-bank\support-bank\SupportBank\log.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
                        
            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
                        
            // Apply config           
            NLog.LogManager.Configuration = config;
        
            ReadFile transactionsCsv = new ReadFile();
            Bank supportBank = transactionsCsv.Read(@"C:\Training\support-bank\support-bank\DodgyTransactions2015.csv");

            try 
            {
                if (args[0].ToLower() != "list")
                {
                    return;
                }
                if (args[1].ToLower() == "all")
                {
                    
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