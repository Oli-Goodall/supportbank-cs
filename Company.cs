using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace SupportBank
{
    public class Company
    {
        public List<Person> Staff;
        public List<Transaction> ListOfTransactions;
        public HashSet<string> ListOfPeopleNames;
        public Dictionary<string, Person> Accounts;
        public Company()
        {
            Staff = new List<Person>();
            // var transactions = new List<Transaction>();
            using (var reader = new StreamReader("Transactions2014.csv"))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                ListOfTransactions = csvReader.GetRecords<Transaction>().ToList();
            }
            ListOfPeopleNames = CsvData.GetNameList(ListOfTransactions);
            this.Accounts = GetAccounts();

        }
        private Dictionary<string, Person> GetAccounts()
        {
            List<Person> listOfPerson = new List<Person>();
            foreach (var personName in this.ListOfPeopleNames)
            {
                listOfPerson.Add(new Person(personName, 0));
            }

            Dictionary<string, Person> accounts = new Dictionary<string, Person>();
            foreach (var person in listOfPerson)
            {
                accounts.Add(person.Name, person);
            }
            foreach (var personName in ListOfPeopleNames)
            {
                foreach (var transaction in ListOfTransactions)
                {
                    if (transaction.FromName == personName)
                    {
                        accounts[personName].From.Add(transaction);
                    }
                    if (transaction.ToName == personName)
                    {
                        accounts[personName].To.Add(transaction);
                    }
                }
            }

            return accounts;
        }

        public void GetBalances()
        {
            foreach (string name in ListOfPeopleNames)
            {
                double totalAmount = 0;
                foreach (Transaction transaction in Accounts[name].From)
                {
                    totalAmount += transaction.TransactionAmount;
                }
                foreach (Transaction transaction in Accounts[name].To)
                {
                    totalAmount -= transaction.TransactionAmount;
                }
                Accounts[name].Balance = Math.Round(totalAmount, 2);
            }

        }
    }
}