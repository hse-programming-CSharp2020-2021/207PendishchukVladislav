using System;

namespace Task10
{
    class Program
    {
        // Метод, валидирующий введенное вещественное значение.
        static bool Read(out double x)
        {
            return (double.TryParse(Console.ReadLine(), out x));
        }

        // Метод, табулирующий функцию для заданных коэффициентов.
        static void FuncTab(double a, double b, double c)
        {
            // Изменение аргумента с заданным шагом.
            for (double x = 1; Math.Round(x, 2) <= 2; x += 0.05)
            {
                // Вычисление значения функции и ее табулирование.
                if (x < 1.2)
                {
                    Console.WriteLine($"y({Math.Round(x, 2)})\t\t\t{a * x * x + b * x + c}");
                }
                else if (x == 1.2)
                {
                    Console.WriteLine($"y({Math.Round(x, 2)})\t\t\t{a / x + Math.Sqrt(x * x + 1)}");
                }
                else
                {
                    Console.WriteLine($"y({Math.Round(x, 2)})\t\t\t{(a + b * x) / Math.Sqrt(x * x + 1)}");
                }
            }
        }

        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Введите значения коэффициентов a, b, c:");

            // Валидация коэффициентов.
            if (Read(out a) && Read(out b) && Read(out c))
            {
                FuncTab(a, b, c);
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
            }
        }
    }
}