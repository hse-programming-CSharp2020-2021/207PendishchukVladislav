using System;

namespace ArraysHW_Task03
{
    class Program
    {
        // Метод, формирующий массив заданной длины по данной формуле.
        public static int[] FormArray(int length, int a, int d)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = a + i * d;
            }

            return array;
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
            int n, a, d;
            int.TryParse(Console.ReadLine(), out n);
            int.TryParse(Console.ReadLine(), out a);
            int.TryParse(Console.ReadLine(), out d);

            PrintArray(FormArray(n,a,d));
        }
    }
}
