using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rowLength = 1;
            int rowsCount = 0;
            int nCntr = n;

            // Вычисление количества строк.
            while (nCntr > 0)
            {
                nCntr -= rowLength;
                rowsCount++;
                rowLength++;
            }

            // Вычисление длины последней строки.
            int lastArrayLength = n - rowsCount * (rowsCount - 1) / 2;

            // Инициализация зубчатого массива.
            int[][] array = new int[rowsCount][];

            // Формирование строк.
            for (int i = 0; i < rowsCount - 1; i++)
            {
                array[i] = new int[i + 1];
            }
            array[rowsCount - 1] = new int[lastArrayLength];

            // Заполнение массива.
            int currentNumber = n;
            for (int y = 0; y < array.Length; y++)
            {
                for (int x = 0; x < array[y].Length; x++)
                {
                    array[y][x] = currentNumber;
                    currentNumber -= 1;
                }
            }

            // Вывод массива.
            for (int y = 0; y < array.Length; y++)
            {
                for (int x = 0; x < array[y].Length; x++)
                {
                    Console.Write(array[y][x] + " \t");
                }
                Console.WriteLine();
            }
        }
    }
}
