using System;
using System.IO;

namespace SupportBank
{
    class ReadFile
    {
        public void Read()
        {
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
                        Transaction singleLine = new Transaction(DateTime.Parse(values[0]), values[1], values[2], values[3], Convert.ToDouble(values[4]));
                    }
                }
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