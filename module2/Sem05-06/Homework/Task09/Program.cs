using System;
using System.ComponentModel;
using System.Linq;

namespace Task09
{
    // Класс линейных уравнений.
    class LinearEquation
    {
        // Коэффициенты линейного уравнения.
        private int a, b, c;

        // Корень X уравнения.
        public double X { get; private set; }

        // Конструктор класса.
        public LinearEquation(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            CalculateRoots();
        }

        // Метод, вычисляющий значение корня уравнения.
        private void CalculateRoots()
        {
            if (a == 0)
            {
                if (b != c)
                {
                    X = double.MinValue;
                }
                else
                {
                    X = double.MaxValue;
                }
            }
            else
            {
                X = (double)(c - b) / a;
            }
        }

        // Метод, выводящий информацию о корнях уравнения.
        public void PrintRoots()
        {
            string bCoef = b >= 0 ? $"+ {b}" : $"- {b * (-1)}";
            string root = X == double.MaxValue ? "all real numbers." : X == double.MinValue ? "no roots." : X.ToString();
            Console.WriteLine($"Equation: {a}x {bCoef} = {c}; Roots: {root}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int N;
                do
                {
                    Console.Write("Введите N: ");
                } while (!int.TryParse(Console.ReadLine(), out N) || N <= 0);

                // Создание и генерация массива.

                LinearEquation[] equations = new LinearEquation[N];
                Random rand = new Random();

                for (int i = 0; i < equations.Length; i++)
                {
                    equations[i] = new LinearEquation(rand.Next(-10, 11), rand.Next(-10, 11), rand.Next(-10, 11));
                }

                // Сортировка по возрастанию по значению корня уравнения.
                equations = equations.OrderBy(o => o.X).ToArray();

                // Вывод данных об уравнениях массива и их корней.
                foreach (var equation in equations)
                {
                    equation.PrintRoots();
                }

                Console.WriteLine(Environment.NewLine + "Нажмите Enter, чтобы выйти, или нажмите иную клавишу, чтобы продолжить.");
                if (Console.ReadKey().Key == ConsoleKey.Enter) break;
                else Console.Clear();
            }
        }
    }
}
