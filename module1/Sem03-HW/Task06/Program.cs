using System;

namespace Task06
{
    class Program
    {
        // Метод для вычисления факториала заданного числа.
        static int Fact(int k)
        {
            if (k == 1)
            {
                return 1;
            }
            else
            {
                int res = 1;
                for (int i = 1; i <= k; i++)
                {
                    res *= i;
                }

                return res;
            }
        }

        // Метод, вычисляющий первую функцию для данного значения x.
        static double S1(double x)
        {
            // Переменная для вычисления суммы.
            double sum = 0;

            // Переменная для хранения предыдущего значения суммы (в конце предыдущей итерации).
            double prevSum = -1;

            int k = 0;

            // Цикл работает до тех пор, пока предыдущее и новое значения суммы различны и сумма не равняется + бесконечности.
            while (prevSum != sum && sum != Double.PositiveInfinity)
            {
                k += 1;
                prevSum = sum;
                sum += ((double)(2 * k - 1) * Math.Pow(x, 2 * k)) / (Fact(2 * k));
            }

            // Возвращается значение суммы до того, как она становится равной + бесконечности.
            return prevSum;
        }

        // Метод, вычисляющий вторую функцию для данного значения x.
        static double S2(double x)
        {
            // Переменная для вычисления суммы.
            double sum = 0;

            // Переменная для хранения предыдущего значения суммы (в конце предыдущей итерации).
            double prevSum = -1;

            int k = 0;

            // Цикл работает до тех пор, пока предыдущее и новое значения суммы различны и сумма не равняется + бесконечности.
            while (prevSum != sum && sum != Double.PositiveInfinity)
            {
                k += 1;
                prevSum = sum;
                sum += Math.Pow(x, k) / Fact(k);
            }

            // Возвращается значение суммы до того, как она становится равной + бесконечности.
            return prevSum;
        }

        static void Main(string[] args)
        {
            int x;
            Console.Write("Введите значение x: ");
            bool read = int.TryParse(Console.ReadLine(), out x);

            if (read)
            {
                Console.WriteLine("Функция S1(n), n = 1, ..., x\t\tЗначение функции");
                for (int i = 1; i <= x; i++)
                {
                    Console.WriteLine($"S1({i})\t\t\t\t\t{S1(i)}");
                }

                Console.WriteLine(Environment.NewLine + "Функция S2(n), n = 1, ..., x\t\tЗначение функции");
                for (int i = 1; i <= x; i++)
                {
                    Console.WriteLine($"S2({i})\t\t\t\t\t{S2(i)}");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
                return;
            }
        }
    }
}
