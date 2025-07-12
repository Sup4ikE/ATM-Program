namespace Bankomat_Lab1;

public class SortaccByBalance : IComparer<Client>
{
    public int Compare(Client? x, Client? y)
    {
        if (x is Client clientX && y is Client clientY)
        {
            return clientX.Account.Balance.CompareTo(clientY.Account.Balance);
        }
        throw new Exception("Objects are not of type Client");
    }
}