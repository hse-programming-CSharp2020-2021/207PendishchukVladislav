using System;

namespace ArraysHW_Task01
{
    class Program
    {
        // Метод, формирующий массив из степеней двойки от 1 до length - 1.
        public static int[] FormArray(int length)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = (int) Math.Pow(2, i);
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
            int n;
            int.TryParse(Console.ReadLine(), out n);
            PrintArray(FormArray(n));
            Console.ReadLine();
        }
    }
}
