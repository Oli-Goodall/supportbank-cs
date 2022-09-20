using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // for csv
            Company TechSwitch = new Company();
            TechSwitch.GetBalances(); //Put all staff in dic and calculate the staff balance
            PrintOut.AskUserWhatNeedToDo(TechSwitch);

            //for json
        }
    }
}
