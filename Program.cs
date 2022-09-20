namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // for csv
            Company TechSwitch = CsvReader.ReadFromFile("Transactions2014.csv");
            TechSwitch.GetBalances(); //Put all staff in dic and calculate the staff balance
            PrintOut.AskUserWhatNeedToDo(TechSwitch);

            //for json
        }
    }
}
