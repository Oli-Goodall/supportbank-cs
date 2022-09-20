namespace SupportBank
{
    public class CsvData
    {
        public static HashSet<string> GetNameList(List<Transaction> transactions)
        {
            HashSet<string> fromNameHSet = new HashSet<string>();
            HashSet<string> toNameHSet = new HashSet<string>();
            foreach (var item in transactions)
            {
                fromNameHSet.Add(item.FromName);
                toNameHSet.Add(item.ToName);
            }

            toNameHSet.UnionWith(fromNameHSet);
            return toNameHSet;
        }
    }
}