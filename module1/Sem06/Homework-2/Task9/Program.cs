using System;

namespace Task9
{
    class Program
    {
        // Метод, генерирующий массив заданной длины с целыми значениями в интервале [-10, 10];
        static int[] GenerateArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++) array[i] = rand.Next(-10, 11);

            return array;
        }

        // Метод, выполняющий меняющий порядок следования элементов в переданном массиве.
        static void ArrayHill(ref int[] array)
        {
            Array.Sort(array);
            int[] oddArray = new int[0];
            int[] evenArray = new int[0];

            for (int i = 0; i < array.Length; i++)
            {
                if ((i + 1) % 2 != 0)
                {
                    Array.Resize(ref oddArray, oddArray.Length + 1);
                    oddArray[oddArray.Length - 1] = array[i];
                }
                else
                {
                    Array.Resize(ref evenArray, evenArray.Length + 1);
                    evenArray[evenArray.Length - 1] = array[i];
                }
            }

            Array.Reverse(evenArray);

            for (int i = 0; i < oddArray.Length; i++)
            {
                array[i] = oddArray[i];
            }

            for (int i = oddArray.Length; i < array.Length; i++)
            {
                array[i] = evenArray[i - oddArray.Length];
            }
        }

        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите длину массива n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            int[] array = GenerateArray(n);

            // Вывод сгенерированного массива.
            Console.Write(Environment.NewLine);
            foreach (var element in array)
            {
                Console.Write(element + " \t");
            }

            ArrayHill(ref array);

            // Вывод измененного массива.
            Console.Write(Environment.NewLine);
            foreach (var element in array)
            {
                Console.Write(element + " \t");
            }
        }
    }
}
