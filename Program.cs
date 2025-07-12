using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using Bankomat_Lab1;

class Program
{
    static void Main(string[] args)
    {
       
        Bank bank = new Bank();
        
        bank.CreateClient("John Doe", "1234", 2000, new DateTime(2008, 1, 11)); // Номер рахунку - 1000
        bank.CreateClient("Jane Smith", "4321", 300, new DateTime(2000, 5, 09)); // 1001
        bank.CreateClient("Alice Brown", "9876", 800, new DateTime(2012, 3, 20)); // 1002
        
        // Sort:
        // // Name
        // bank.SortAccountByName();
        //
        // Console.WriteLine("Sorting by name: ");
        // bank.DisplayAccounts();
        //
        // // Date
        // bank.SortAccountsByCreationDate();
        //
        // Console.WriteLine("\nSorting by creation date: ");
        // bank.DisplayAccounts();
        //
        // // Balance
        // bank.SortAccountsByBalance();
        //
        // Console.WriteLine("\nSorting by balance: ");
        // bank.DisplayAccounts();
        
        // ICloneable - не знав як зробити
        
        while (true)
        {
            Console.Write("Enter number of raxunku: ");
            if (int.TryParse(Console.ReadLine(), out int accountNumber))
            {
                Client client = bank.GetClientByAccountNumber(accountNumber);
                if (client != null)
                {
                    if(AuthenticateClient(client))
                    {
                        Menu(client);
                    }
                }
                else
                {
                    Console.WriteLine("Account number not found");
                }
            }
            else
            {
                Console.WriteLine("Not a valid number");
            }
        }
    }

    static bool AuthenticateClient(Client client)
    {
        int attempts = 3;
        while (attempts > 0)
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (password == client.Account.Password)
            {
                Console.WriteLine("Your password is correct, Welcome!");
                return true;
            }
            else
            {
                Console.WriteLine("Your password is incorrect");
                attempts--;
            }
        }
        Console.WriteLine("Atempts 0");
        return false;
    }


    static void Menu(Client client)
    {
        while (true)
        {
            Console.Write("\nWelcome to MENU!\n");
            Console.WriteLine("1.Print Balance");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("4.Exit");
            
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write(client.Account.Balance);
                    break;
                case "2":
                    Console.WriteLine("Write sum to deposit");
                    client.Account.Deposit(int.Parse(Console.ReadLine()));
                    break;
                case "3":
                    Console.WriteLine("Write sum to withdraw");
                    if (client.Account.Withdraw(int.Parse(Console.ReadLine())))
                    {
                        Console.Write("Operation is complite");
                    }
                    else
                    {
                        Console.WriteLine("Operation is not complite");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Not a valid input");
                    break;
            }
        }
    }
    
    
}