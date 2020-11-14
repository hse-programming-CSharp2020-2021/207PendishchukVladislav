using System;

namespace Task11
{
    // Класс геометрических прогрессий.
    class GeometricProgression
    {
        // Начальное значение прогрессии.
        private double _start;

        // Инкремент.
        private double _increment;


        // Конструкторы класса.

        public GeometricProgression()
        {
            _start = 0;
            _increment = 1;
        }

        public GeometricProgression(double start, double increment)
        {
            _start = start;
            _increment = increment;
        }


        // Индексатор, возвращающий значение index-ого члена прогресси.
        public double this[int index]
        {
            get
            {
                return _start * Math.Pow(_increment, index - 1);
            }
        }

        // Метод, возвращающий информацию о прогрессии в строковом виде.
        public override string ToString()
        {
            string result =
                $"Первый член прогрессии: {_start}, инкремент: {_increment}. Первые пять членов прогрессии:" +
                Environment.NewLine;

            for (int i = 1; i < 6; i++)
            {
                result += " " + this[i];
            }

            return result;
        }

        // Метод, возвращающий сумму первых n членов прогрессии.
        public double GetSum(int n)
        {
            return (_start * (1 - Math.Pow(_increment, n))) / (1 - _increment);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Ввод данных об отдельном объекте-прогрессии.

                double start;
                do
                {
                    Console.Write("Введите начальное значение последовательности: ");
                } while (!double.TryParse(Console.ReadLine(), out start));

                double increment;
                do
                {
                    Console.Write("Введите инкремент последовательности: ");
                } while (!double.TryParse(Console.ReadLine(), out increment));

                Console.WriteLine();

                GeometricProgression indProgression = new GeometricProgression(start, increment);

                Random rand = new Random();

                // Создание массива случайных геометрических прогрессий.

                int N = rand.Next(5, 16);
                GeometricProgression[] geomProgArray = new GeometricProgression[N];

                // Заполнение массива.
                for (int i = 0; i < geomProgArray.Length; i++)
                {
                    geomProgArray[i] = new GeometricProgression(rand.Next(0, 10) + rand.NextDouble(), rand.Next(0, 4) + rand.NextDouble());
                }

                int step = rand.Next(3, 16);

                // Вывод информации о прогрессиях с step-ым элементом большим, чем в отдельной.
                foreach (var geomProg in geomProgArray)
                {
                    if (geomProg[step] > indProgression[step])
                    {
                        Console.WriteLine(geomProg.ToString());
                        Console.WriteLine();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine();

                // Вывод суммы первых step членов прогрессий в массиве.
                for (int i = 0; i < geomProgArray.Length; i++)
                {
                    Console.WriteLine($"Сумма первых {step} членов прогрессии {i + 1}: {geomProgArray[i].GetSum(step)}");
                }

                Console.WriteLine(Environment.NewLine + "Нажмите Enter, чтобы выйти, или нажмите иную клавишу, чтобы продолжить.");
                if (Console.ReadKey().Key == ConsoleKey.Enter) break;
                else Console.Clear();
            }
        }
    }
}
