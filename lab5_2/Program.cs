using System;

namespace lab5_2
{
    class MatrixMultiply
    {
        static void Main()
        {
            int[,] a = new int[2, 2];
            int[,] b = new int[2, 2];
            int[,] result = new int[2, 2];

            Console.WriteLine("Введите 4 числа для заполнения массива a:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Введите 4 числа для заполнения массива b:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    b[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Multiply(a, b, result);

            Console.WriteLine("Результат умножения матриц:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Multiply(int[,] a, int[,] b, int[,] result)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
        }
    }
}
