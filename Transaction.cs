using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace SupportBank
{
    public class Transaction
    {
        [Name("Date")]
        public string TransactionDate { get; set; }
        [Name("From")]
        public string FromName { get; set; }
        [Name("To")]
        public string ToName { get; set; }
        [Name("Narrative")]
        public string TransactionNarrative { get; set; }
        [Name("Amount")]
        public double TransactionAmount { get; set; }
    
        public Transaction()
        {
            TransactionDate = "";
            FromName = "";
            ToName = "";
            TransactionNarrative = "";
            TransactionAmount = 0;
        }
    }
}