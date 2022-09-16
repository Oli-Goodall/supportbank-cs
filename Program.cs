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
            Company TechSwitch = new Company();
            TechSwitch.GetBalances();
            PrintOut.ShowMeMyBalance(TechSwitch, PrintOut.WhoAreYou());


            // double total = 0;
            // foreach (var transaction in TechSwitch.Accounts["Sarah T"].From)
            // {
            //     if (transaction.ToName == "Ben B")
            //     {
            //         total += transaction.TransactionAmount;
            //         Console.WriteLine($"At {transaction.TransactionDate}, {transaction.FromName} gave {transaction.ToName} amount £{transaction.TransactionAmount}.");

            //     }
            // }

            // Console.WriteLine(Math.Round(total, 2));
        }
    }
}
