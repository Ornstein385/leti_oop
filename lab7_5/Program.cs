using System;

namespace lab7_5
{
    interface IPrintable
    {
        void Print();
    }

    class Coordinate : IPrintable
    {
        private double x;
        private double y;

        public Coordinate()
        {
            x = 0.0;
            y = 0.0;
        }

        public Coordinate(double px, double py)
        {
            x = px;
            y = py;
        }

        public void Print()
        {
            Console.WriteLine("({0},{1})", x, y);
        }
    }
    class Utils
    {
        public static void Display(object item)
        {
            IPrintable ip = item as IPrintable;
            if (ip != null)
            {
                ip.Print();
            }
            else
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static bool IsItFormattable(object x)
        {
            if (x is IFormattable)
                return true;
            else
                return false;
        }

        public static int Greater(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static bool Factorial(int n, out int answer)
        {
            int k;
            int f;
            bool ok = true;

            if (n < 0)
                ok = false;

            try
            {
                checked
                {
                    f = 1;
                    for (k = 2; k <= n; ++k)
                    {
                        f *= k;
                    }
                }
            }
            catch (Exception)
            {
                f = 0;
                ok = false;
            }

            answer = f;
            return ok;
        }

        public static bool RecursiveFactorial(int n, out int f)
        {
            bool ok = true;

            if (n < 0)
            {
                f = 0;
                ok = false;
            }

            if (n <= 1)
                f = 1;
            else
            {
                try
                {
                    int pf;
                    checked
                    {
                        ok = RecursiveFactorial(n - 1, out pf);
                        f = n * pf;
                    }
                }
                catch (Exception)
                {
                    f = 0;
                    ok = false;
                }
            }

            return ok;
        }
    }

    public class Test
    {
        public static void Main()
        {
            int num = 65;
            string msg = "A String";
            Coordinate c = new Coordinate(21.0, 68.0);
            Utils.Display(num);
            Utils.Display(msg);
            Utils.Display(c);
        }
    }
}
