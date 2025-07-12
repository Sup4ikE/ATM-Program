namespace Bankomat_Lab1;

public class Client: IComparable<Client>
{
    public string Name { get; }
    public Account Account { get; }
    
    public Client(string name, int accountNumber, string password, decimal initialBalance, DateTime acctimeDate)
    {
        Name = name;
        Account = new Account(accountNumber, password, initialBalance, acctimeDate);
    }

    public int CompareTo(Client? other)
    { 
        return string.Compare(this.Name, other.Name);
    }
    
}