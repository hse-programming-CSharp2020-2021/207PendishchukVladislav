using System;

namespace MyLib
{
    public class Matrix
    {
        public int[,] matrix;

        // Получение значения целочисленного параметра
        public int GetIntValue(string comment)
        {
            Console.Write(comment);
            return int.Parse(Console.ReadLine());
        }

        public void MatrPrint(int[,] ar)
        {
            // Вывод в консоль двумерного массива в виде матрицы

            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.Write(ar[i, j] + " \t");
                }
                Console.WriteLine();
            }
        }

        public int[,] UnitMatr(int n)
        {
            // Сформировать единичную матрицу:
            if (n <= 0) throw new ArgumentOutOfRangeException("Аргумент метода должен быть положительным!");

            int[,] ar = new int[n, n];
            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                ar[i, j] = (i == j ? 1 : 0);
            return ar;
        }
    }
}
