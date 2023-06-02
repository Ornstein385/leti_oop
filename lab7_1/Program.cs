using System;

namespace lab7_1
{
    class BankAccount
    {
        enum AccountType
        {
            Checking,
            Deposit
        }

        private long accNo;
        private decimal accBal;
        private AccountType accType;

        private static long nextNumber = 123;

        public void Populate(decimal balance)
        {
            accNo = NextNumber();
            accBal = balance;
            accType = AccountType.Checking;
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

    class Test
    {
        static void Main()
        {
            BankAccount b1 = new BankAccount();
            BankAccount b2 = new BankAccount();

            b1.Populate(100);
            b2.Populate(100);

            Console.WriteLine("Account 1 - Type: {0}, Number: {1}, Balance: {2}", b1.Type(), b1.Number(), b1.Balance());
            Console.WriteLine("Account 2 - Type: {0}, Number: {1}, Balance: {2}", b2.Type(), b2.Number(), b2.Balance());

            b1.TransferFrom(b2, 10);

            Console.WriteLine("Transfer complete.");

            Console.WriteLine("Account 1 - Type: {0}, Number: {1}, Balance: {2}", b1.Type(), b1.Number(), b1.Balance());
            Console.WriteLine("Account 2 - Type: {0}, Number: {1}, Balance: {2}", b2.Type(), b2.Number(), b2.Balance());

            Console.ReadLine();
        }
    }
}
