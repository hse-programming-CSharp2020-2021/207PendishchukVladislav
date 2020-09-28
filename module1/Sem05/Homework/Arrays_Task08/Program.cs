using System;
using System.Runtime.InteropServices;

namespace Arrays_Task08
{
    class Program
    {
        // Метод, формирующий массив заданной длины по определенной формуле.
        public static double[] FormArray(int length)
        {

            double[] array = new double[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = ((i * (i + 1)) / 2) % length;
            }

            return array;
        }

        // Метод, нормирующий массив относительно максимального по модулю элемента.
        public static void NormalizeArray(ref double[] array)
        {
            double maximum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > Math.Abs(maximum)) maximum = array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] /= maximum;
            }
        }

        // Метод, выводящий в консоль все элементы массива через горизонтальную табуляцию.
        public static void PrintArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(Math.Round(array[i], 3) + "\t");
            }

            Console.Write(Environment.NewLine);
        }

        // Метод, генерирующий массив с случайными вещественными значениями и нормирующий его,
        // после чего выводя его начальное и нормированное состояние.
        public static void GenerateAndNormalizeArray(int length)
        {
            Random rand = new Random();
            double[] array = new double[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(-1000, 1000) + rand.NextDouble();
            }

            PrintArray(array);
            NormalizeArray(ref array);
            PrintArray(array);
        }

        static void Main(string[] args)
        {

        }
    }
}
