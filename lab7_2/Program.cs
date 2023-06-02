using System;

namespace lab7_2
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

        public static void Reverse(ref string s)
        {
            string sRev = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sRev += s[i];
            }
            s = sRev;
        }
    }

    class Test
    {
        static void Main()
        {
            string message;
            Console.WriteLine("Enter a message:");
            message = Console.ReadLine();
            BankAccount.Reverse(ref message);
            Console.WriteLine("Reversed message: " + message);
            Console.ReadKey();
        }
    }
}
