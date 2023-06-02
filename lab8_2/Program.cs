using System;
using System.Collections;

namespace lab8_2
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
    }

    class CreateAccount
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount();
            BankAccount acc2 = new BankAccount(BankAccount.AccountType.Deposit);
            BankAccount acc3 = new BankAccount(100);
            BankAccount acc4 = new BankAccount(BankAccount.AccountType.Deposit, 500);

            Console.WriteLine("Account 1: " + acc1.Number() + ", " + acc1.Type() + ", " + acc1.Balance());
            Console.WriteLine("Account 2: " + acc2.Number() + ", " + acc2.Type() + ", " + acc2.Balance());
            Console.WriteLine("Account 3: " + acc3.Number() + ", " + acc3.Type() + ", " + acc3.Balance());
            Console.WriteLine("Account 4: " + acc4.Number() + ", " + acc4.Type() + ", " + acc4.Balance());

            acc1.Deposit(100);
            acc2.Withdraw(50);
            acc3.Deposit(200);
            acc4.Withdraw(100);

            Console.WriteLine("Account 1 Transactions:");
            foreach (BankTransaction tran in acc1.Transactions())
            {
                Console.WriteLine(tran.When() + " - " + tran.Amount());
            }

            Console.WriteLine("Account 2 Transactions:");
            foreach (BankTransaction tran in acc2.Transactions())
            {
                Console.WriteLine(tran.When() + " - " + tran.Amount());
            }

            Console.WriteLine("Account 3 Transactions:");
            foreach (BankTransaction tran in acc3.Transactions())
            {
                Console.WriteLine(tran.When() + " - " + tran.Amount());
            }

            Console.WriteLine("Account 4 Transactions:");
            foreach (BankTransaction tran in acc4.Transactions())
            {
                Console.WriteLine(tran.When() + " - " + tran.Amount());
            }
        }
    }
}
