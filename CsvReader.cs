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
                List<Transaction> transactions = csvReader.GetRecords<Transaction>().ToList();
                return new Company(transactions);
            }
        }
    }
}
