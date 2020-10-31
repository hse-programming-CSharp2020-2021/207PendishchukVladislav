using System;
using System.Runtime.CompilerServices;

namespace Task02
{
    class Program
    {
        /// <summary>
        /// Метод валидации и записи целого числа в переменную.
        /// </summary>
        /// <param name="number"> Переменная для записи. </param>
        /// <returns></returns>
        static bool Read(out int number)
        {
            return int.TryParse(Console.ReadLine(), out number);
        }

        /// <summary>
        /// Метод генерации двумерного массива n на n.
        /// </summary>
        /// <param name="n"> Размер массива. </param>
        /// <returns> Двумерный массив. </returns>
        static int[][] GenerateArray(int n)
        {
            int[][] array = new int[n][];

            int[] row = new int[n];

            for (int i = 0; i < row.Length; i++)
            {
                row[i] = i + 1;
            }

            int[] firstRow = new int[n];
            Array.Copy(row, firstRow, row.Length);
            array[0] = firstRow;

            for (int k = 1; k < n; k++)
            {
                int[] rowCopy = new int[n];
                Array.Copy(row, rowCopy, row.Length);
                for (int i = 0; i < rowCopy.Length; i++)
                {
                    int tmp = row[0];
                    if (i != rowCopy.Length - 1)
                    {
                        rowCopy[i] = rowCopy[i + 1];
                    }
                    else
                    {
                        rowCopy[i] = tmp;
                    }
                }

                array[k] = rowCopy;
                Array.Copy(rowCopy, row, rowCopy.Length);
            }

            return array;
        }

        static void Main(string[] args)
        {
            int n;

            // Ввод целого числа.
            do
            {
                Console.WriteLine("Введите целое ненулевое число N: ");
            } while (!Read(out n) || n <= 0);


            // Генерация массива.
            int[][] array = GenerateArray(n);

            // Вывод массива на экран.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i][j].ToString().PadRight(10));
                }

                Console.WriteLine();
            }
        }
    }
}
