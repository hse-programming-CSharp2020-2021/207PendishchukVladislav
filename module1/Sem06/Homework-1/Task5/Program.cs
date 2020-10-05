using System;

namespace Task5
{
    class Program
    {
        // Метод, случайно генерирующий квадратную матрицу заданного размера с вещественными значениями.
        static double[,] GenerateMatrix(int n)
        {
            Random rand = new Random();
            double[,] matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) matrix[i, j] = rand.Next(0, 25) + Math.Round(rand.NextDouble(), 2);
            }

            return matrix;
        }

        
        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите число (размер квадратной матрицы): ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            // Генерация матрицы.
            double[,] matrix = GenerateMatrix(n);

            // Вывод сгенерированной матрицы.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " \t");
                }
                Console.Write(Environment.NewLine);
            }

            // Инициализация матриц-областей.
            double[,] area_1 = new double[n,n];
            double[,] area_2 = new double[n,n];
            double[,] area_3 = new double[n,n];
            double[,] area_4 = new double[n,n];

            // Выделение областей в матрицы.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Область 1.
                    if (i > j && i + j < n - 1)
                    {
                        area_1[i, j] = matrix[i, j];
                    }

                    // Область 2.
                    if ((i > j && i + j > n - 1) || (i > (n - 1) / 2 && (i + j == n - 1 || i == j)))
                    {
                        area_2[i, j] = matrix[i, j];
                    }

                    // Область 3.
                    if ((i < j && i + j < n - 1) || (i > j && i + j > n - 1))
                    {
                        area_3[i, j] = matrix[i, j];
                    }

                    // Область 4.
                    if (i < j && i + j < n - 1 && j < n / 2 || i > j && i + j > n - 1 && (j >= n / 2 && n % 2 == 0 || j > n / 2 && n % 2 != 0))
                    {
                        area_4[i, j] = matrix[i, j];
                    }
                }
            }
            
            // Вывод областей.

            Console.WriteLine("\nОбласть 1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(area_1[i, j] + " \t");
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("\nОбласть 2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(area_2[i, j] + " \t");
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("\nОбласть 3:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(area_3[i, j] + " \t");
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine("\nОбласть 4:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(area_4[i, j] + " \t");
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
