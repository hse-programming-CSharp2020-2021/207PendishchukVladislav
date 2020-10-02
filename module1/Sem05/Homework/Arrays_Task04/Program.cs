using System;

namespace Arrays_Task04
{
    class Program
    {
        // Метод, заполняющий массив по заданному рекуррентному соотношению с переданным первым элементом.
        public static int[] FormArray(int a_0)
        {
            int length = 0;
            int prevA = a_0;

            // Вычисление длины массива.
            while (a_0 != 1)
            {
                length += 1;
                a_0 = (a_0 % 2 == 0) ? (a_0 / 2) : (3 * a_0 + 1);
            }

            // Формирование массива.
            int[] array = new int[length];
            array[0] = prevA;
            for (int i = 1; i < length; i++)
            {
                array[i] = (array[i - 1] % 2 == 0) ? (array[i - 1] / 2) : (3 * array[i - 1] + 1);
            }

            return array;
        }
        
        // Метод, выводящий элементы массива с их индексами в консоль по 5 элеменов на строку.
        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"[{i+1}] = {array[i]} \t");
                if ((i + 1) % 5 == 0) Console.Write(Environment.NewLine);
            }
        }

        static void Main(string[] args)
        {
            int a_0;
            do Console.Write("Введите число: ");
            while (!int.TryParse(Console.ReadLine(), out a_0));
            int[] array = FormArray(a_0);
            Print(array);
        }
    }
}
