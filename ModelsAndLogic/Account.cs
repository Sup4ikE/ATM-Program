using System.Runtime.Intrinsics.X86;

namespace Bankomat_Lab1;

public class Account
{
    public int AccountNumber { get; }
    public string Password { get; }
    public decimal Balance { get; private set; }
    
    public DateTime CreationDate { get; set; }
    
    public Account(int accountNumber, string password, decimal initialBalance, DateTime creationDate)
    {
        AccountNumber = accountNumber;
        Password = password;
        Balance = initialBalance;
        CreationDate = creationDate; 
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("You don't have enough money");
            return false;
        }
        Balance -= amount;
        return true;
    }
    
}
