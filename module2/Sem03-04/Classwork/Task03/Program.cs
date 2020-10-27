using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Emit;

namespace Task03
{
    // Класс правильных многоугольников.
    class Polygon
    {
        // Количество сторон в многоугольнике.
        private int sides;

        // Радиус вписанной окружности.
        private double radius;

        // Конструктор с умалчиваемыми значениями.
        public Polygon(int sidesNum = 3, double radiusNum = 1)
        {
            sides = sidesNum;
            radius = radiusNum;
        }

        // Свойство - периметр многоугольника.
        public double Perimeter
        {
            get
            {
                double angle = Math.Tan(Math.PI / sides);
                return sides * angle * radius * 2;
            }
        }

        // Свойство - площадь многоугольника.
        public double Area
        {
            get
            {
                return Perimeter * radius / 2;
            }
        }

        // Метод получения информации о многоугольнике.
        public void GetPolygonInfo(ConsoleColor color = ConsoleColor.Gray)
        {
            Console.WriteLine("Кол-во сторон: " + sides + "\nРадиус вписанной окружности: " + radius);
            Console.ForegroundColor = color;
            Console.WriteLine("Площадь фигуры: " + Area);
            Console.ResetColor();
            Console.WriteLine("Периметр фигуры: " + Perimeter);
        }
    }

    class Program
    {
        // Метод валидации введенного целочисленного значения.
        static bool Read(out int x)
        {
            return int.TryParse(Console.ReadLine(), out x);
        }

        // Метод валидации введенного вещественного числа.
        static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        static void Main(string[] args)
        {
            List<Polygon> polygons = new List<Polygon>();
            int n = 1;
            int sides;
            double radius;

            do
            {
                Console.WriteLine($"Объект {n}");
                do
                {
                    Console.WriteLine("Введите число сторон или введите 0, чтобы завершить: ");
                } while (!Read(out sides) || (sides != 0 && sides < 3));

                if (sides == 0) break;


                do
                {
                    Console.WriteLine("Введите радиус вписанной окружности: ");
                } while (!Read(out radius) || radius <= 0);

                polygons.Add(new Polygon(sides, radius));
                n++;
            } while (true);


            double maxArea = 0;
            double minArea = double.MaxValue;

            for (int i = 0; i < polygons.Count; i++)
            {
                if (polygons[i].Area < minArea)
                {
                    minArea = polygons[i].Area;
                }

                if (polygons[i].Area > maxArea)
                {
                    maxArea = polygons[i].Area;
                }
            }


            for (int i = 0; i < polygons.Count; i++)
            {
                Console.WriteLine($"\nОбъект {i + 1}");
                Console.WriteLine();
                if (polygons[i].Area == maxArea)
                {
                    polygons[i].GetPolygonInfo(ConsoleColor.Red);
                } else if (polygons[i].Area == minArea)
                {
                    polygons[i].GetPolygonInfo(ConsoleColor.Green);
                }
                else
                {
                    polygons[i].GetPolygonInfo();
                }
                Console.WriteLine();
            }
        }
    }
}
