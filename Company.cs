namespace SupportBank
{
    public class Company
    {
        public List<Transaction> transactions;
        public HashSet<string> peopleNames;
        public Dictionary<string, Person> Accounts;

        public Company(List<Transaction> transactions)
        {
            this.transactions = transactions;
            peopleNames = NameListMaker.GetNameList(transactions);
            this.Accounts = GetAccounts();
        }

        private Dictionary<string, Person> GetAccounts()
        {
            List<Person> listOfPerson = new List<Person>();
            foreach (var personName in this.peopleNames)
            {
                listOfPerson.Add(new Person(personName, 0));
            }

            Dictionary<string, Person> accounts = new Dictionary<string, Person>();
            foreach (var person in listOfPerson)
            {
                accounts.Add(person.Name, person);
            }
            foreach (var personName in peopleNames)
            {
                foreach (var transaction in transactions)
                {
                    if (transaction.FromName == personName)
                    {
                        accounts[personName].From.Add(transaction);
                        accounts[personName].UpdateBalance(transaction);
                    }
                    if (transaction.ToName == personName)
                    {
                        accounts[personName].To.Add(transaction);
                        accounts[personName].UpdateBalance(transaction);
                    }
                }
            }
            return accounts;
        }


    }
}
