using System;
using System.Collections.Generic;

namespace ArraysHW_Task04
{
    class Program
    {
        // Метод, формирующий массив заданной длины, состоящий из чисел ряда Фибоначчи, начиная от 1.
        public static int[] FormFibonacciArray(int length)
        {
            int[] array = new int[length];
            array[0] = 1;
            array[1] = 1;
            for (int i = 2; i < length; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
            }

            return array;
        }

        // Метод, "переворачивающий" массив задом наперед.
        public static void ReverseArray(ref int[] array)
        {
            int tmp;
            for (int i = 0; i < array.Length / 2; i++)
            {
                tmp = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = tmp;
            }
        }

        // Метод, выводящий в консоль все элементы массива через горизонтальную табуляцию.
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }

            Console.Write(Environment.NewLine);
        }

        static void Main(string[] args)
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);
            int[] fibonacci = FormFibonacciArray(n);
            ReverseArray(ref fibonacci);
            PrintArray(fibonacci);
        }
    }
}
