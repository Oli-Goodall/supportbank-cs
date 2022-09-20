using NLog;
using NLog.Config;
using NLog.Targets;



namespace SupportBank
{
    class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
        
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Users\LeoNg\Work\supportbank\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            Company TechSwitch = CsvReader.ReadFromFile("Transactions2014.csv");
            PrintOut.AskUserWhatNeedToDo(TechSwitch);

            Logger.Debug("Hello");
    
           
            
        }
    }
}
