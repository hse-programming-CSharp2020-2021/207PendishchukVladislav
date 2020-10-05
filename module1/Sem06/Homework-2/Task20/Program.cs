using System;

namespace Task20
{
    class Program
    {
        // Метод, генерирующий массив заданной длины целочисленных значений в интервале [10, 100].
        static int[] GenerateArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++) array[i] = rand.Next(10, 101);

            return array;
        }

        // Метод, дублирующий в переданном массиве все вхождения числа x.
        static void ArrayItemDouble(ref int[] array, int x)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == x)
                {
                    Array.Resize(ref array, array.Length + 1);
                    for (int j = array.Length - 1; j > i + 1; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    array[i + 1] = array[i];
                    i += 1;
                }
            }
        }

        static void Main(string[] args)
        {
            int n, x;
            do Console.Write("Введите длину массива n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            do Console.Write("Введите значение x: ");
            while (!int.TryParse(Console.ReadLine(), out x) || x <= 0);

            int[] array = GenerateArray(n);

            // Вывод сгенерированного массива.
            foreach (var element in array)
            {
                Console.Write(element + " \t");
            }
            Console.Write(Environment.NewLine);

            ArrayItemDouble(ref array, x);

            // Вывод измененного массива.
            foreach (var element in array)
            {
                Console.Write(element + " \t");
            }
        }
    }
}
