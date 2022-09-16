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
                    PrintOut.ShowAllStaffBalance(TechSwitch); //show all staff balance
                }
                else if (input == 2)
                {
                    Console.WriteLine("Pleace select a account");
                    int counter = 1;
                    foreach (var name in TechSwitch.ListOfPeopleNames)
                    {
                        Console.WriteLine($"{counter}. {name}");
                        counter++;
                    }
                    PrintOut.ShowMeMyBalance(TechSwitch, PrintOut.WhoAreYou());
                }
                else if (input == 3)
                {
                    Console.WriteLine($"====   We have total {TechSwitch.ListOfPeopleNames.Count()} accounts  ====");
                    int counter = 1;
                    foreach (var name in TechSwitch.ListOfPeopleNames)
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
