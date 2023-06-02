using System;

namespace lab4_1
{
    class Utils
    {
        public static int Greater(int a, int b)
        {
            return a > b ? a : b;
        }
    }

    class Test
    {
        static void Main()
        {
            int x, y, greater;

            Console.Write("Введите число x: ");
            x = int.Parse(Console.ReadLine());

            Console.Write("Введите число y: ");
            y = int.Parse(Console.ReadLine());

            greater = Utils.Greater(x, y);

            Console.WriteLine("Большее число: " + greater);
        }
    }
}
