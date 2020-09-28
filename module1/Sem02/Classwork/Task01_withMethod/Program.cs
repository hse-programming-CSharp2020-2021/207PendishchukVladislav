using System;

namespace Task01_withMethod
{
    class Program
    {
        // Метод для вычисления по формуле Бине
        public static int Bine(uint n)
        {
            double b = (1 + Math.Sqrt(5)) / 2;
            double un = (Math.Pow(b, n) - Math.Pow(-b, -n)) / (2 * b - 1);
            return (int)(un + 0.5);
        }

        public static void Main()
        {
            do
            {
                // Номер числа в ряду
                uint num;

                // Результат вычисления
                int result;

                // Строка ввода
                string line;
                do
                {
                    Console.Write("Введите номер члена ряда: ");
                    line = Console.ReadLine();
                } while (!uint.TryParse(line, out num));
                result = Bine(num);
                Console.WriteLine("число Фибоначчи: " + result);
                Console.WriteLine("Для выхода нажмите клавишу Enter");
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
    }
}
