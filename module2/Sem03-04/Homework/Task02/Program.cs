using System;
using System.Threading;

namespace Task02
{
    class Point
    {
        // Автореализуемые свойства X и Y (декартовы координаты точки). 
        public double X { get; set; }
        public double Y { get; set; }

        // Конструктор класса Point.
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Консруктор умолчания класса Point.
        public Point() : this (0,0) { }

        /// <summary>
        /// Свойсво - информация о точке.
        /// </summary>
        public string PointInfo
        {
            get
            {
                return $"X = {X}, Y = {Y}, Ro = {Rho}, Phi = {Phi}";
            }
        }

        /// <summary>
        /// Свойство - полярная координата 'ро' точки.
        /// </summary>
        public double Rho
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }

        /// <summary>
        /// Свойство - полярная координата 'фи' точки.
        /// </summary>
        public double Phi
        {
            get
            {
                if (X > 0)
                {
                    if (Y >= 0) return Math.Atan(Y / X);
                    else return Math.Atan(Y / X) + 2*Math.PI;
                } else if (X < 0)
                {
                    return Math.Atan(Y / X) + Math.PI;
                }
                else
                {
                    if (Y > 0) return Math.PI / 2;
                    else if (Y == 0) return 0;
                    else return (3 * Math.PI) / 2;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация массива точек.
            Point[] pointArray = new Point[3];

            // Создание двух объектов-точек.
            pointArray[0] = new Point(3, 4);
            pointArray[1] = new Point(10, 23);

            // Ввод координат точки C.

            double x_C, y_C;
            do
            {
                Console.Write("Введите координату x точки C: ");
            } while (!double.TryParse(Console.ReadLine(), out x_C));

            do
            {
                Console.Write("Введите координату у точки C: ");
            } while (!double.TryParse(Console.ReadLine(), out y_C));

            // Создание объекта с введенными координатами.
            pointArray[2] = new Point(x_C, y_C);

            // Сортировка массива по значению координаты ро.
            if (pointArray[0].Rho > pointArray[1].Rho)
            {
                Point tmp = pointArray[0];
                pointArray[0] = pointArray[1];
                pointArray[1] = tmp;
            }
            if (pointArray[0].Rho > pointArray[2].Rho)
            {
                Point tmp = pointArray[0];
                pointArray[0] = pointArray[2];
                pointArray[2] = tmp;
            }
            if (pointArray[1].Rho > pointArray[2].Rho)
            {
                Point tmp = pointArray[1];
                pointArray[1] = pointArray[2];
                pointArray[2] = tmp;
            }

            // Вывод информации о точках.
            foreach (var point in pointArray)
            {
                Console.WriteLine(point.PointInfo);
            }
        }
    }
}
