using System.Globalization;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    public static class CsvReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static Company ReadFromFile(string path)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Training\supportbank-cs\SupportBank\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
            using (var reader = new StreamReader(path))
            using (var csvReader = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Read();
                csvReader.ReadHeader();
                List<Transaction> listOfTransactions = new List<Transaction>();
                while (csvReader.Read())
                {
                    try
                    {
                        Transaction transaction = csvReader.GetRecord<Transaction>();
                        listOfTransactions.Add(transaction);
                    }
                    catch (CsvHelper.TypeConversion.TypeConverterException ex)
                    {
                        Logger.Error(ex);

                    }
                }
                // List<Transaction> transactions = csvReader.GetRecords<Transaction>().ToList();
                return new Company(listOfTransactions);
            }
        }
    }
}
