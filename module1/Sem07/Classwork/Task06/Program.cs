using System;
using System.Collections.Generic;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите элементы массива через точку с запятой: ");
            string input = Console.ReadLine();

            // Деление массива на элементы.
            string[] elements = input.Split(';');

            // Выделение целочисленных значений из массива.
            List<int> integers = new List<int>();
            int dummy;
            foreach (var element in elements)
            {
                if (int.TryParse(element, out dummy)) integers.Add(int.Parse(element));
            }

            // Вывод массива и подсчёт суммы элементов.
            Console.WriteLine("Массив целых чисел из массива:");
            int sum = 0;
            foreach (var element in integers)
            {
                sum += element;
                Console.Write(element + " \t");
            }
            Console.WriteLine();

            // Вывод среднего арифметического элементов.
            double average = (double)sum / integers.Count;
            Console.WriteLine($"Среднее значение: {Math.Round(average, 3)}");
        }
    }
}
