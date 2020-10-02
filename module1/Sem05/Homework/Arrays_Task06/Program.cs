using System;

namespace Arrays_Task06
{
    class Program
    {
        // Метод, выполняющий единократное сжатие массива.
        static int[] Compress(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if ((array[i] + array[i + 1]) % 3 == 0)
                {
                    array[i] = array[i] * array[i + 1];
                    for (int j = i + 1; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    Array.Resize(ref array, array.Length - 1);
                }
            }

            return array;
        }

        // Метод, выполняющий максимально возможное сжатие массива.
        static int[] MaxCompress(int[] array)
        {
            int[] initArray;
            do
            {
                initArray = array;
                array = Compress(array);
            } while (initArray != array);

            return array;
        }


        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите число: ");
            while (!int.TryParse(Console.ReadLine(), out n));

            // Формирование случайного массива из n элементов.
            int[] array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-10, 11);
            }

            Console.WriteLine("Изначальный массив: ");

            foreach (var element in array) Console.Write(element + "\t");
            Console.WriteLine(Environment.NewLine);

            // Вызов метода сжатия массива.
            array = MaxCompress(array);

            Console.WriteLine("Сжатый массив: ");

            foreach (var element in array) Console.Write(element + "\t");
        }
    }
}
