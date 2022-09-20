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

        public double Balance;
        public string Name;

        public Person(string name, double balance)
        {
            this.Name = name;
            this.Balance = balance;
            this.From = new List<Transaction>();
            this.To = new List<Transaction>();
        }

    }
}