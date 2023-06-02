using System;
using System.Collections;
using System.IO;

namespace lab8_3
{
    class BankAccount
    {
        public enum AccountType
        {
            Checking,
            Deposit
        }

        private long accNo;
        private decimal accBal;
        private AccountType accType;
        private Queue tranQueue = new Queue();

        private static long nextNumber = 123;

        public BankAccount()
        {
            accNo = NextNumber();
            accType = AccountType.Checking;
            accBal = 0;
        }

        public BankAccount(AccountType aType)
        {
            accNo = NextNumber();
            accType = aType;
            accBal = 0;
        }

        public BankAccount(decimal aBal)
        {
            accNo = NextNumber();
            accType = AccountType.Checking;
            accBal = aBal;
        }

        public BankAccount(AccountType aType, decimal aBal)
        {
            accNo = NextNumber();
            accType = aType;
            accBal = aBal;
        }

        public bool Withdraw(decimal amount)
        {
            bool sufficientFunds = accBal >= amount;
            if (sufficientFunds)
            {
                accBal -= amount;
                BankTransaction tran = new BankTransaction(amount);
                tranQueue.Enqueue(tran);
            }
            return sufficientFunds;
        }

        public decimal Deposit(decimal amount)
        {
            accBal += amount;
            BankTransaction tran = new BankTransaction(amount);
            tranQueue.Enqueue(tran);
            return accBal;
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

        private static long NextNumber()
        {
            return nextNumber++;
        }

        public Queue Transactions()
        {
            return tranQueue;
        }

        public void TransferFrom(BankAccount accForm, decimal amount)
        {
            bool success = accForm.Withdraw(amount);
            if (success)
            {
                this.Deposit(amount);
            }
        }
    }

    class BankTransaction
    {
        private readonly decimal amount;
        private readonly DateTime when;

        public BankTransaction(decimal tranAmount)
        {
            amount = tranAmount;
            when = DateTime.Now;
        }

        public decimal Amount()
        {
            return amount;
        }

        public DateTime When()
        {
            return when;
        }

        ~BankTransaction()
        {
            StreamWriter swFile = File.AppendText("Transactions.Dat");
            swFile.WriteLine("Date/Time: {0}\tAmount: {1}", when, amount);
            swFile.Close();
            GC.SuppressFinalize(this);
        }
    }

    class CreateAccount
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount();
            acc1.Deposit(100);
            acc1.Withdraw(50);
            acc1.Deposit(200);
            acc1.Withdraw(100);

            Console.Write("Account 1 Balance: ");
            Console.WriteLine(acc1.Balance());
        }
    }
}
