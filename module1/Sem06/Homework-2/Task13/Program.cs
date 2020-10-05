using System;

namespace Task13
{
    class Program
    {
        // Метод, генерирующий массив целочисленных элементов в интервале [0, 40] заданной длины.
        static int[] GenerateArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++) array[i] = rand.Next(0, 41);

            return array;
        }

        // Метод, выводящий элементы массива, имеющие порядковый номер, кратный k.
        static void PrintElements(int[] array, int k)
        {
            for (int i = k - 1; i < array.Length; i += k)
            {
                Console.Write(array[i] + " \t");
            }
        }

        static void Main(string[] args)
        {
            int n;
            do Console.Write("Введите число n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            int k;
            do Console.Write("Введите число k: ");
            while (!int.TryParse(Console.ReadLine(), out k) || k > n);

            int[] array = GenerateArray(n);

            foreach (var element in array)
            {
                Console.Write(element + " \t");
            }
            Console.Write(Environment.NewLine);

            PrintElements(array, k);
        }
    }
}
