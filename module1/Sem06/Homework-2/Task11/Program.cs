using System;
using System.Reflection.Metadata.Ecma335;

namespace Task11
{
    class Program
    {
        // Метод, генерирующий массив заданной длины по данной формуле.
        static ulong[] GenerateArray(int length)
        {
            ulong[] array = new ulong[length];
            array[0] = 0;
            array[1] = 1;
            for (int i = 2; i < length; i++)
            {
                array[i] = 34 * array[i - 1] - array[i - 2] + 2;
            }

            return array;
        }

        // Метод, выводящий элементы массива.
        static void Print(ulong[] array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " \t");
            }
        }

        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите число: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0);

            Print(GenerateArray(n));
        }
    }
}
