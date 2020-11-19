using System;
using System.Collections.Generic;
using System.Linq;
using Figures;

namespace Task02
{
    class Program
    {

        // Метод, создающий массив фигур случайной длины и случайных параметров.
        public static Point[] FigArray()
        {
            Random rand = new Random();
            int circleAmount = rand.Next(0, 11);
            int squareAmount = rand.Next(0, 11);
            List<Point> pointList = new List<Point>();

            while (circleAmount != 0 && squareAmount != 0)
            {
                if (circleAmount == 0)
                {
                    pointList.Add(new Square(rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble()));
                    circleAmount--;
                } else if (squareAmount == 0)
                {
                    pointList.Add(new Circle(rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble()));
                    squareAmount--;
                }
                else
                {
                    int cntr = rand.Next(0, 2);
                    if (cntr == 0)
                    {
                        pointList.Add(new Square(rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble()));
                        circleAmount--;
                    }
                    else
                    {
                        pointList.Add(new Circle(rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble(), rand.Next(10, 100) + rand.NextDouble()));
                        squareAmount--;
                    }
                }
            }

            return pointList.ToArray();
        }

        static void Main(string[] args)
        {
            // Создание массива.
            Point[] arr = FigArray();
            int circleAmount = 0, squareAmount = 0;
            double circleAreaSum = 0, circlePerimeterSum = 0, squareAreaSum = 0, squarePerimeterSum = 0;

            // Расчёт даннвх для каждого типа объектов.
            foreach (var figure in arr)
            {
                if (figure is Circle)
                {
                    circleAmount++;
                    circleAreaSum += figure.Area;
                    circlePerimeterSum += Math.Sqrt(figure.Area / Math.PI) * 2 * Math.PI;
                } else if (figure is Square)
                {
                    squareAmount++;
                    squareAreaSum += figure.Area;
                    squarePerimeterSum += Math.Sqrt(figure.Area) * 4;
                }
            }

            // Вывод информации о двух типах объектов в массиве.
            Console.WriteLine($"Amount of circles: {circleAmount}, average area: {circleAreaSum / circleAmount:f3}, average perimeter: {circlePerimeterSum / circleAmount:f3}.");
            Console.WriteLine($"Amount of squares: {squareAmount}, average area: {squareAreaSum / squareAmount:f3}, average perimeter: {squarePerimeterSum / squareAmount:f3}.");

            // Вывод информации об объектах массива до сортировки.
            Console.WriteLine(Environment.NewLine + "Array before sorting: ");
            foreach (var obj in arr)
            {
                Console.WriteLine($"Object area: {obj.Area:f3}");
            }

            // Сортировка.
            Array.Sort(arr, (x, y) => x.Area.CompareTo(y.Area));

            // Вывод после сортировки.
            Console.WriteLine(Environment.NewLine + "Array after sorting: ");
            foreach (var obj in arr)
            {
                Console.WriteLine($"Object area: {obj.Area:f3}");
            }
        }
    }
}
