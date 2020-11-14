using System;

namespace Task10
{
    // Класс окружностей.
    class Circle
    {
        // Координаты центра окружности.
        public int x { get; private set; }
        public int y { get; private set; }

        // Радиус окружности.
        public double radius { get; private set; }

        // Конструктор класса.
        public Circle(int x, int y, double radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        // Метод, возвращающий true при пересечении окружности с иной, переданной в аргументах.
        public bool IntersectsWith(Circle circle)
        {
            double distance = Math.Sqrt((x - circle.x) * (x - circle.x) + (y - circle.y) * (y - circle.y));

            return distance > circle.radius - radius && distance < circle.radius + radius;
        }

        // Метод, возвращающий строку с данными об окружности.
        public override string ToString()
        {
            return $"Координаты центра окружности: [{x};{y}]. Радиус: {radius}";
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

                // Создание массива окружностей.

                Circle[] circles = new Circle[N];
                Random rand = new Random();

                for (int i = 0; i < circles.Length; i++)
                {
                    circles[i] = new Circle(rand.Next(1, 16), rand.Next(1, 16), rand.Next(1, 16));
                }


                // Создание отдельной окружности.

                int x;
                do
                {
                    Console.Write("Введите координату x центра окружности: ");
                } while (!int.TryParse(Console.ReadLine(), out x));

                int y;
                do
                {
                    Console.Write("Введите координату y центра окружности: ");
                } while (!int.TryParse(Console.ReadLine(), out y));

                int radius;
                do
                {
                    Console.Write("Введите радиус окружности: ");
                } while (!int.TryParse(Console.ReadLine(), out radius));

                Circle indCircle = new Circle(x, y, radius);

                // Вывод информации об окружностях в массиве.

                foreach (var circle in circles)
                {
                    Console.WriteLine(circle.ToString());
                }


                // Вывод информации об окружностях в массиве, пересекающихся с отдельной окружностью.

                Console.WriteLine("============================================");
                Console.WriteLine(Environment.NewLine + "Объекты, пересекающиеся с объектом " + indCircle.ToString() + ":");

                Console.WriteLine();
                foreach (var circle in circles)
                {
                    if (circle.IntersectsWith(indCircle)) Console.WriteLine(circle.ToString());
                }
            }
        }
    }
}
