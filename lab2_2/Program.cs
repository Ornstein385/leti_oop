using System;

namespace hw2_task2
{
    public enum AccountType { 
        Checking, Deposite
    }
    public struct BankAccount {
        long accNo;
        decimal accBal;
        AccountType accType;

        public BankAccount(long accNo, decimal accBal, AccountType accType) {
            this.accNo = accNo;
            this.accBal = accBal;
            this.accType = accType;
        }

        public string toString() {
            return "num: " + accNo.ToString() + ", bal: " + accBal.ToString() + ", type: " + accType;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(111, 777, AccountType.Deposite);
            Console.WriteLine(account.toString());
        }
    }
}
