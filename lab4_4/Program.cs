using System;

namespace lab4_4
{
    using System;

    class Utils
    {
        public static int Greater(int a, int b)
        {
            return a > b ? a : b;
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static bool Factorial(int n, out int answer)
        {
            if (n < 0)
            {
                throw new Exception();
            }
            answer = 1;
            try
            {
                for (int i = 1; i <= n; i++)
                {
                    checked
                    {
                        answer *= i;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int RecursiveFactorial(int n)
        {
            if (n < 0)
            {
                throw new Exception();
            }
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * RecursiveFactorial(n - 1);
            }
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

            int n;
            Console.Write("Введите число для вычисления факториала: ");
            n = int.Parse(Console.ReadLine());

            int answer;
            try
            {
                if (Utils.Factorial(n, out answer))
                {
                    Console.WriteLine("Факториал числа {0} равен {1}", n, answer);
                }
                else
                {
                    Console.WriteLine("Ошибка: переполнение");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: отрицательный аргумент");
            }

            try
            {
                int recursiveFactorial = Utils.RecursiveFactorial(n);
                Console.WriteLine("Рекурсивный факториал числа {0} равен {1}", n, recursiveFactorial);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: отрицательный аргумент");
            }
        }
    }
}
