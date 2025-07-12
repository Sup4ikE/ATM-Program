namespace Bankomat_Lab1;

public class SortAccByDate: IComparer<Client>
{
    public int Compare(Client? x, Client? y)
    {
        if (x is Client clientX && y is Client clientY)
        {
            return clientX.Account.CreationDate.CompareTo(clientY.Account.CreationDate);
        }
        throw new Exception("Objects are not of type Client");
    }
}