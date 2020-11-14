using System;
using System.Runtime.CompilerServices;

namespace Task02
{
    class Program
    {
        /// <summary>
        /// Метод генерации двумерного массива n на n.
        /// </summary>
        /// <param name="n"> Размер массива. </param>
        /// <returns> Двумерный массив. </returns>
        static int[][] GenerateArray(string[] input)
        {
            int[] row = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                row[i] = Convert.ToInt32(input[i]);
            }

            int[][] array = new int[row.Length][];

            int[] firstRow = new int[row.Length];
            Array.Copy(row, firstRow, row.Length);
            array[0] = firstRow;

            for (int k = 1; k < row.Length; k++)
            {
                int[] rowCopy = new int[row.Length];
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

        // Метод вывода зубчатого массива.
        private static void PrintJaggedArray(int[][] array)
        {
            if (array == null) return;

            foreach (var line in array)
            {
                foreach (var num in line)
                {
                    Console.Write(num);
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            PrintJaggedArray(GenerateArray(Console.ReadLine().Split(',')));
        }
    }
}
