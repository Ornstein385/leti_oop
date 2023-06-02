using System;

namespace hw2
{

    enum AccountType{
        Checking, Diposite
    }
    class Program
    {
        static void Main(string[] args)
        {
            AccountType goldAccount = AccountType.Checking;
            AccountType platinumAccount = AccountType.Diposite;
            Console.WriteLine(goldAccount);
            Console.WriteLine(platinumAccount);
        }
    }
}
