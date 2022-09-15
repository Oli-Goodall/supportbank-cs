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
            var transactions = new List<Transaction>();
            using (var reader = new StreamReader("Transactions2014.csv"))
            using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                transactions = csvReader.GetRecords<Transaction>().ToList();
            }

            HashSet<string> listOfPeople = CsvData.GetNameList(transactions);
            
            List<Person> listOfPerson = new List<Person>();
            foreach (var personName in listOfPeople)
            {
                listOfPerson.Add(new Person(personName, 0));
            }

            Dictionary<string, Person> dic = new Dictionary<string, Person>();
            foreach (var person in listOfPerson)
            {
                dic.Add(person.Name, person);
            }

            foreach (var personName in listOfPeople)
            {
                foreach (var transaction in transactions)
                {
                    if(transaction.FromName == personName)
                    {
                        dic[personName].From.Add(transaction);
                    }
                    if(transaction.ToName == personName)
                    {
                        dic[personName].To.Add(transaction);
                    }
                }
            }
            
            double total = 0;
            foreach (var transaction in dic["Sarah T"].From)
            {
                if(transaction.ToName == "Ben B")
                {
                    total += transaction.TransactionAmount;
                    Console.WriteLine($"At {transaction.TransactionDate}, {transaction.FromName} gave {transaction.ToName} amount £{transaction.TransactionAmount}.");

                }
            }

            Console.WriteLine(Math.Round(total, 2));

            


        
            

            

        }
    }    
}
