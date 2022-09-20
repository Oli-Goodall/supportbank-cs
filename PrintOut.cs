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

        public static void AskUserWhatNeedToDo(Company company)
        {
            Console.WriteLine("====  Welcome to TechSwitch support bank!!  ====");
            Console.WriteLine("====  Please select what you want to do?  ====");
            Console.WriteLine("1. Check all account balance");
            Console.WriteLine("2. Check one account balance");
            Console.WriteLine("3. Get list of account");
            int input = 0;
            do
            {
                input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    PrintOut.ShowAllStaffBalance(company);
                }
                else if (input == 2)
                {
                    Console.WriteLine("Pleace select a account");
                    int counter = 1;
                    foreach (var name in company.ListOfPeopleNames)
                    {
                        Console.WriteLine($"{counter}. {name}");
                        counter++;
                    }
                    PrintOut.ShowMeMyBalance(company, PrintOut.WhoAreYou());
                }
                else if (input == 3)
                {
                    Console.WriteLine($"====   We have total {company.ListOfPeopleNames.Count()} accounts  ====");
                    int counter = 1;
                    foreach (var name in company.ListOfPeopleNames)
                    {
                        Console.WriteLine($"{counter}. {name}");
                        counter++;
                    }
                }
                else
                {
                    Console.WriteLine("Please input 1 or 2 or 3");
                }
            } while (input != 1 && input != 2 && input != 3);
        }


    }
}