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

        HashSet< string > listOfPeople = CsvData.GetNameList(transactions);
        
        }
    }    
}
