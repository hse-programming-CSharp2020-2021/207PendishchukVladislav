using System;

namespace Task09
{
    class Program
    {
        // Метод, валидирующий введенное целочисленное значение.
        static bool Read(out int x)
        {
            return (int.TryParse(Console.ReadLine(), out x));
        }

        // Метод, выполняющий поиск среднего арифметического введенных отрицательных чисел.
        static void FindAverage()
        {
            // Переменная, сохраняющая очередное введенное значение.
            int x;

            // Сумма введенных отрицательных чисел.
            int sum = 0;

            // Кол-во введенных отрицательных чисел.
            int amount = 0;

            // Среднее арифметическое.
            double average;

            Console.WriteLine("Введите целые числа, нажимая Enter после ввода каждого числа.");
            Console.WriteLine("Чтобы окончить ввод и получить среднее арифметическое отрицательных чисел, нажмите Escape.");

            // Повторение цикла, пока сумма не станет меньше -1000 или пока пользователь не нажмет Escape.
            do
            {
                if (Read(out x))
                {
                    if (x < 0)
                    {
                        sum += x;
                        amount++;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод!");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape && sum >= -1000);

            average = (double)sum / amount;

            Console.WriteLine(Environment.NewLine + $"Среднее арифметическое: {average}");
        }

        static void Main(string[] args)
        {
            FindAverage();
        }
    }
}