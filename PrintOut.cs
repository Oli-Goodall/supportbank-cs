using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace SupportBank
{
    public class PrintOut
    {

        public static string? WhoAreYou()
        {
            Console.WriteLine("What is your name?");
            string? MyName = Console.ReadLine();
            return MyName;
        }

        public static void ShowMeMyBalance(Company company, string? name)
        {   
            if(name == "all")
            {
                foreach (string item in company.ListOfPeopleNames)
            {
                Console.WriteLine($"{item} has a balance of £{company.Accounts[item].Balance}");
            }
            }

            if (name != null && name != "all")
            {
                if (company.Accounts[name].Balance > 0)
                {
                    Console.WriteLine($"Hello, {name}. You owe £{company.Accounts[name].Balance}.");
                }
                else
                {
                    Console.WriteLine($"Hello, {name}. You are owed £{Math.Abs(company.Accounts[name].Balance)}.");
                }
            }
        }

        public static void ShowAllStaffBalance(Company company)
        {
            foreach (string name in company.ListOfPeopleNames)
            {
                Console.WriteLine($"{name} has a balance of £{company.Accounts[name].Balance}");
            }
            
        }


    }
}