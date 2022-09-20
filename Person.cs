namespace SupportBank
{
    public class Person
    //Jon
    {
        //   Date         Account       Account
        // 01/01/2014    Jon -7.8      Sarah T +7.8
        // return        Jon  7.8      Sarah T -7.8                                       

        //From Jon to sarah
        public List<Transaction> From;
        public List<Transaction> To;

        public double Balance{get; private set;}
        public string Name;

        public Person(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
            this.From = new List<Transaction>();
            this.To = new List<Transaction>();
        }

        public void UpdateBalance(Transaction transaction)
        {
            if(transaction.FromName == Name)
            {
                Balance -= transaction.TransactionAmount;
                this.Balance = Math.Round(Balance, 2);
            }
            if(transaction.ToName == Name)
            {
                Balance += transaction.TransactionAmount;
                this.Balance = Math.Round(Balance, 2);
            }   
        }

    }
}