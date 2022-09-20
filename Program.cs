namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // for csv
            Company TechSwitch = CsvReader.ReadFromFile("Transactions2014.csv");
            PrintOut.AskUserWhatNeedToDo(TechSwitch);
            //for json
        }
    }
}
