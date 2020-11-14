using System;

namespace Task08
{
    // Класс точек.
    class Point
    {
        // Координаты точки.
        private double x, y;

        // Конструктор класса по умолчанию.
        public Point()
        {
            x = 0;
            y = 0;
        }

        // Конструктор класса.
        public Point(double xValue, double yValue)
        {
            x = xValue;
            y = yValue;
        }

        // Свойства-координаты (read-only).

        public double X
        {
            get
            {
                return x;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
        }

        // Метод, вычисляющий расстояние между двумя точками.
        public double Distance(Point dest)
        {
            return Math.Round(Math.Sqrt((x - dest.X) * (x - dest.X) + (y - dest.Y) * (y - dest.Y)), 2);
        }

        // Метод, возвращающий строку с данными о точке.
        public override string ToString()
        {
            return $"X: {x}, Y: {y}";
        }
    }

    // Класс треугольников.
    class Triangle
    {
        // Точки-вершины треугольника.
        private Point point1, point2, point3;

        // Конструктор класса по координатам точек.
        public Triangle(double x_1, double y_1, double x_2, double y_2, double x_3, double y_3)
        {
            Point tmpPoint1 = new Point(x_1, y_1);
            Point tmpPoint2 = new Point(x_2, y_2);
            Point tmpPoint3 = new Point(x_3, y_3);
            if (tmpPoint1.Distance(tmpPoint2) + tmpPoint2.Distance(tmpPoint3) > tmpPoint1.Distance(tmpPoint3) &&
                tmpPoint1.Distance(tmpPoint2) + tmpPoint1.Distance(tmpPoint3) > tmpPoint2.Distance(tmpPoint3) &&
                tmpPoint2.Distance(tmpPoint3) + tmpPoint1.Distance(tmpPoint3) > tmpPoint1.Distance(tmpPoint2))
            {
                point1 = tmpPoint1;
                point2 = tmpPoint2;
                point3 = tmpPoint3;
            }
        }

        // Конструктор класса по точкам-вершинам.
        public Triangle(Point p1, Point p2, Point p3)
        {
            Point tmpPoint1 = p1;
            Point tmpPoint2 = p2;
            Point tmpPoint3 = p3;
            if (tmpPoint1.Distance(tmpPoint2) + tmpPoint2.Distance(tmpPoint3) > tmpPoint1.Distance(tmpPoint3) &&
                tmpPoint1.Distance(tmpPoint2) + tmpPoint1.Distance(tmpPoint3) > tmpPoint2.Distance(tmpPoint3) &&
                tmpPoint2.Distance(tmpPoint3) + tmpPoint1.Distance(tmpPoint3) > tmpPoint1.Distance(tmpPoint2))
            {
                point1 = tmpPoint1;
                point2 = tmpPoint2;
                point3 = tmpPoint3;
            }
        }

        // Метод, возвращающий значение периметра треугольника.
        public double Perimeter()
        {
            return Math.Round(point1.Distance(point2) + point2.Distance(point3) + point1.Distance(point3), 3);
        }

        // Метод, возвращающий значение площади треугольникаю
        public double Area()
        {
            double halfPerimeter = Perimeter() / 2;
            return Math.Round(Math.Sqrt(halfPerimeter * (halfPerimeter - point1.Distance(point2)) *
                                        (halfPerimeter - point2.Distance(point3)) *
                                        (halfPerimeter - point1.Distance(point3))), 3);
        }

        // Метод, возвращающий строку с информацией о треугольнике.
        public override string ToString()
        {
            if (point1 == null)
            {
                return "Is not a triangle." + Environment.NewLine;
            }
            else
            {
                return "Point 1: " + point1.ToString() + Environment.NewLine +
                       "Point 2: " + point2.ToString() + Environment.NewLine +
                       "Point 3: " + point3.ToString() + Environment.NewLine +
                       "==============================" + Environment.NewLine
                       + $"Area: {Area()}" + Environment.NewLine
                       + $"Perimeter: {Perimeter()}" + Environment.NewLine;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random rand = new Random();
                int N = rand.Next(5, 16);

                Triangle[] triangles = new Triangle[N];

                for (int i = 0; i < triangles.Length; i++)
                {
                    triangles[i] = new Triangle(rand.Next(-10, 11), rand.Next(-10, 11),
                        rand.Next(-10, 11), rand.Next(-10, 11),
                        rand.Next(-10, 11), rand.Next(-10, 11));
                }

                foreach (var triangle in triangles)
                {
                    Console.WriteLine(triangle.ToString());
                }

                Console.WriteLine("Нажмите Enter, чтобы продолжить, и любую иную клавишу, чтобы выйти");

                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}
