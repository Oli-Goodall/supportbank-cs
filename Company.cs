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

        public Company(List<Person> allStaff)
        {
            this.Staff = allStaff;
        }
    }
}