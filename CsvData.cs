using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace SupportBank
{
    public class CsvData
    {
        public static HashSet<string> GetNameList(List<Transaction> transactions)
        {
            HashSet<string> fromNameHSet = new HashSet<string>();
            foreach (var item in transactions)
            {
                fromNameHSet.Add(item.FromName);
            }

            HashSet<string> toNameHSet = new HashSet<string>();
            foreach (var item in transactions)
            {
                toNameHSet.Add(item.ToName);
            }

            toNameHSet.UnionWith(fromNameHSet);
            return toNameHSet;
        }
    }
}