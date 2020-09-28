using System;

namespace ArraysHW_Task02
{
    class Program
    {
        // Метод, формирующий массив из нечетных цифр от 1 заданной длины.
        public static int[] ArrayOfOddNumbers(int length)
        {
            int[] array = new int[length];
            array[0] = 1;
            for (int i = 1; i < length; i++)
            {
                array[i] = array[i - 1] + 2;
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
            PrintArray(ArrayOfOddNumbers(n));
            Console.ReadLine();
        }
    }
}
