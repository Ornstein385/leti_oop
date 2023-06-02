using System;

namespace hw1_task4
{
    class Task4
    {
        static bool TryParse(string s)
        {
            try
            {
                int x = int.Parse(s);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string str = "";
            int a, b;
            do
            {
                Console.WriteLine("enter first number");
                str = Console.ReadLine();
            } while (!TryParse(str));
            a = int.Parse(str);
            do
            {
                Console.WriteLine("enter second number");
                str = Console.ReadLine();
            } while (!TryParse(str));
            b = int.Parse(str);
            try
            {
                int c = a / b;
                Console.WriteLine("result: {0}", c);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Div by zero exeption");
            }
        }
    }
}
