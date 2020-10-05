using System;
using System.Runtime.InteropServices;

namespace Task16
{
    class Program
    {
        // Метод, генерирующий массив заданной длины целочисленных элементов из интервала [0, 40].
        static int[] GenerateArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++) array[i] = rand.Next(0, 41);

            return array;
        }

        // Метод, находящий индексы (начиная с 1) минимального и максимального элементов массива и выводящий их сумму и индекс минимального.
        static void FindMinMax(int[] array)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int minIndex = 0, maxIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i + 1;
                }

                if (array[i] < min)
                {
                    min = array[i];
                    minIndex = i + 1;
                }
            }

            Console.WriteLine($"Индекс наименьшего элемента: {minIndex}. Сумма индексов наименьшего и наибольшего элементов: {minIndex + maxIndex}");
        }

        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите число: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            int[] array = GenerateArray(n);

            foreach (var element in array)
            {
                Console.Write(element + " \t");
            }
            Console.Write(Environment.NewLine);

            FindMinMax(array);
        }
    }
}
