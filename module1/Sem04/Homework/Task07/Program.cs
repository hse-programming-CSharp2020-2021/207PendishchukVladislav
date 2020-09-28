using System;

namespace Task07
{
    class Program
    {
        // Метод, валидирующий введенное целочисленное значение.
        static bool Read(out int x)
        {
            return (int.TryParse(Console.ReadLine(), out x) && x >= 0);
        }

        // Метод, вычисляющий НОД и НОК двух введённых чисел.
        static void Calculate(int a, int b, out int div, out int mul)
        {
            // Переменные, сохраняющие изначальные значения чисел (для вычисления НОКа).
            int prevA = a;
            int prevB = b;

            // Вычисление НОДа.
            while (a != b)
            {
                if (a > b) a -= b;
                else b -= a;
            }
            div = a;

            // Вычисление НОКа.
            mul = (prevB * prevA) / div;
        }

        static void Main(string[] args)
        {
            int a, b, multiple, divisor;
            if (Read(out a) && Read(out b))
            {
                Calculate(a, b, out divisor, out multiple);
                Console.WriteLine($"НОД: {divisor}");
                Console.WriteLine($"НОК: {multiple}");
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
            }
        }
    }
}