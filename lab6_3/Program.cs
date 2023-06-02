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

    public decimal Deposit(decimal amount)
    {
        accBal += amount;
        return accBal;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= accBal)
        {
            accBal -= amount;
            return true;
        }
        else
        {
            return false;
        }
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

    static void TestDeposit(BankAccount acc)
    {
        Console.Write("Enter amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        acc.Deposit(amount);
    }

    static void TestWithdraw(BankAccount acc)
    {
        Console.Write("Enter amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        bool success = acc.Withdraw(amount);
        if (success)
        {
            Console.WriteLine("Withdrawal successful");
        }
        else
        {
            Console.WriteLine("Withdrawal unsuccessful: not enough funds");
        }
    }

    static void Main()
    {
        Console.Write("Enter the account balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        BankAccount berts = NewBankAccount(balance);
        BankAccount freds = NewBankAccount(balance);

        Write(berts);
        Console.WriteLine();
        Write(freds);

        TestDeposit(berts);
        Console.WriteLine("After deposit:");
        Write(berts);

        TestWithdraw(freds);
        Console.WriteLine("After withdrawal:");
        Write(freds);

        Console.ReadKey();
    }
}