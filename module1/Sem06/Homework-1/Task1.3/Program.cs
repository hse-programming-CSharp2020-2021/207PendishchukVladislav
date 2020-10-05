using System;
using System.Runtime.InteropServices;

namespace Task1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите число: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            int[,] matrix = new int[n, n];

            int i = 1;
            int j, k;
            int p = n / 2;

            // Формирование спиральной матрицы.
            for (k = 1; k <= p; k++)
            {
                for (j = k - 1; j < n - k + 1; j++) matrix[k - 1, j] = i++;
                for (j = k; j < n - k + 1; j++) matrix[j, n - k] = i++;
                for (j = n - k - 1; j >= k - 1; --j) matrix[n - k, j] = i++;
                for (j = n - k - 1; j >= k; j--) matrix[j, k - 1] = i++;
            }
            if (n % 2 == 1) matrix[p, p] = n * n;

            // Вывод спиральной матрицы.
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " \t");
                    if (j == n - 1) Console.Write(Environment.NewLine);
                }
            }
        }
    }
}