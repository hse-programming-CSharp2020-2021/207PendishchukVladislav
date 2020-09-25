using System;

namespace Task11
{
    class Program
    {
        // Метод, валидирующий введенное целочисленное значение.
        static bool Read(out int x)
        {
            return (int.TryParse(Console.ReadLine(), out x) && x >= 0);
        }

        // Метод, вычисляющий значение функции для заданных коэффициентов.
        static int Func(int m, int n)
        {
            return (1 << m) + (1 << n);
        }

        static void Main(string[] args)
        {
            int m, n;
            Console.WriteLine("Введите значения коэффициентов m и n:");

            // Валидация коэффициентов.
            if (Read(out m) && Read(out n))
            {
                Console.WriteLine($"Значение функции - {Func(m, n)}");
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
            }
        }
    }
}