using System;

namespace lab4_2
{
    class Utils
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
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

            Console.WriteLine("Исходные значения: x = {0}, y = {1}", x, y);

            Utils.Swap(ref x, ref y);

            Console.WriteLine("Значения после обмена: x = {0}, y = {1}", x, y);

            greater = Utils.Greater(x, y);

            Console.WriteLine("Большее число: " + greater);
        }
    }
}
