using System;

namespace Arrays_Task09
{
    class Program
    {
        // Метод, заменяющий все вхождения максимума в переданном массиве переданным вещественным значением.
        public static void ReplaceMaximums(ref double[] array, double replacerNum)
        {
            double maximum = double.MinValue;
            foreach (var element in array)
            {
                if (element > maximum) maximum = element;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == maximum) array[i] = replacerNum;
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

        static void Main(string[] args)
        {
            double[] array = {5.5, 43.4, -21.6, 7, -10.78, 43.4};
            PrintArray(array);
            double n = double.Parse(Console.ReadLine());
            ReplaceMaximums(ref array, n);
            PrintArray(array);
            Console.ReadLine();
        }
    }
}
