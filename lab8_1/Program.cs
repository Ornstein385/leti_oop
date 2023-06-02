using System;

namespace lab8_1
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
            }
            return sufficientFunds;
        }

        public decimal Deposit(decimal amount)
        {
            accBal += amount;
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

        public void TransferFrom(BankAccount accForm, decimal amount)
        {
            bool success = accForm.Withdraw(amount);
            if (success)
            {
                this.Deposit(amount);
            }
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
        }
    }
}
