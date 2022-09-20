using System.Globalization;

namespace SupportBank
{
    public static class CsvReader
    {
        
        public static Company ReadFromFile(string path)
        {
            
            using (var reader = new StreamReader(path))
            using (var csvReader = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Read();
                csvReader.ReadHeader();
                while(csvReader.Read())
                {
                    try
                    {
                        Transaction transaction = csvReader.GetRecord<Transaction>();
                        transactions.Add(transaction);
                    }
                    catch (CsvHelper.TypeConversion.TypeConverterException ex)
                    {
                        Logger.Error(ex);
                        
                    }
                }
                List<Transaction> transactions = csvReader.GetRecord<Transaction>().ToList();
                return new Company(transactions);
            }
        }
    }
}
