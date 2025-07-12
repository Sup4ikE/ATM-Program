using System.Runtime.InteropServices.JavaScript;

namespace Bankomat_Lab1;

public class Bank
{
    private List<Client> _clients = new List<Client>();
    private int _accountNumberСounter = 1000;

    public Client CreateClient(string name, string password, decimal initialDeposit, DateTime accdateTime)
    {
        int accountNumber = _accountNumberСounter++;
        Client client = new Client(name, accountNumber, password, initialDeposit, accdateTime);
        _clients.Add(client);
        return client;
    }
    
    public Client GetClientByAccountNumber(int accountNumber)
    {
        return _clients.Find(c => c.Account.AccountNumber == accountNumber);
    }
    
    public void SortAccountByName()
    {
        _clients.Sort();
    }
    
    public void SortAccountsByCreationDate()
    {
        _clients.Sort(new SortAccByDate());
    }

    public void SortAccountsByBalance()
    {
        _clients.Sort(new SortaccByBalance());
    }

    public void DisplayAccounts()
    {
        foreach (var account in _clients)
        {
            Console.WriteLine($"Account Number: {account.Account.AccountNumber}, Owner: {account.Name}, Balance: {account.Account.Balance}, Creation Date: {account.Account.CreationDate.ToShortDateString()}");
        }
    }
}