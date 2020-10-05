using System;

namespace Task1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите число: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            int[,] array = new int[n, n];

            // Заполнение матрицы.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == i) array[i, j] = 0;
                    else if (j < i) array[i, j] = 1;
                    else array[i, j] = -1;
                }
            }

            // Вывод матрицы.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + " \t");
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
