using System;

enum AccountType
{
    Checking,
    Deposit
}

class BankAccount
{
    private static long nextAccNo = 123;

    private long accNo;
    private decimal accBal;
    private AccountType accType;

    private static long NextNumber()
    {
        return nextAccNo++;
    }

    public void Populate(decimal balance)
    {
        accNo = NextNumber();
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
    static BankAccount NewBankAccount(decimal balance)
    {
        BankAccount created = new BankAccount();
        created.Populate(balance);
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
        Console.Write("Enter the account balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        BankAccount account1 = NewBankAccount(balance);
        BankAccount account2 = NewBankAccount(balance);

        Write(account1);
        Console.WriteLine();
        Write(account2);

        Console.ReadKey();
    }
}