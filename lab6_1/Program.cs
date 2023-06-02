using System;

enum AccountType
{
    Checking,
    Deposit
}

class BankAccount
{
    private long accNo;
    private decimal accBal;
    private AccountType accType;

    public void Populate(long number, decimal balance)
    {
        accNo = number;
        accBal = balance;
        accType = AccountType.Checking;
    }

    public long Number()
    {
        return accNo;
    }

    public decimal Balance()
    {
        return accBal;
    }

    public string Type()
    {
        return accType.ToString();
    }
}

class CreateAccount
{
    static BankAccount NewBankAccount(long number, decimal balance)
    {
        BankAccount created = new BankAccount();
        created.Populate(number, balance);
        return created;
    }

    static void Write(BankAccount account)
    {
        Console.WriteLine("Account number: " + account.Number());
        Console.WriteLine("Account balance: " + account.Balance());
        Console.WriteLine("Account type: " + account.Type());
    }

    static void Main()
    {
        Console.Write("Enter account number: ");
        long number = long.Parse(Console.ReadLine());

        Console.Write("Enter account balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        BankAccount account = NewBankAccount(number, balance);

        Write(account);

        Console.ReadKey();
    }
}