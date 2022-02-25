using System;
using System.IO;
using System.Text.Json;

namespace SupportBank
{
    public class ReadJsonFile : IReadable
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();       
        public List<InputTransaction> Read(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var readIn = JsonSerializer.Deserialize<List<InputTransaction>>(jsonString);
                return readIn;
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
    
}