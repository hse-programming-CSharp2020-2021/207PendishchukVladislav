using System;

// Пространство имён - классов фигур.
namespace Figures
{
    // Класс точек.
    public class Point
    {
        // Поля - координаты точки.
        public double x, y;

        // Виртуальное свойство - площадь.
        public virtual double Area { get; }

        // Виртуальный меод - вывод информации о точке.
        public virtual void Display()
        {
            Console.WriteLine($"Point - x: {x}, y: {y}");
        }
    }

    // Класс окружностей (кругов).
    public class Circle : Point
    {
        // Поле - радиус окружности.
        private double rad;

        // Свойство - доступ к полю радиуса окружности.
        public double Rad
        {
            get
            {
                return rad;
            }
            set
            {
                rad = value;
            }
        }

        // Свойство только для чтения - длина окружности.
        public double Len
        {
            get
            {
                return 2 * Math.PI * rad;
            }
        }
        
        // Свойство - площади фигуры.
        public override double Area
        {
            get
            {
                return Math.PI * rad * rad;
            }
        }
        
        // Метод - вывод информации о фигуре.
        public override void Display()
        {
            Console.WriteLine($"Circle - radius: {rad}, center x: {x}, center y: {y}");
        }

        // Конструктор класса с тремя аргументами.
        public Circle(double x, double y, double rad)
        {
            this.x = x;
            this.y = y;
            this.rad = rad;
        }
    }

    // Класс квадратов.
    public class Square : Point
    {
        // Поле - длина стороны квадрата.
        private double side;

        // Свойство - доступ к полю длины стороны.
        public double Side
        {
            get
            {
                return side;
            }
            set
            {
                side = value;
            }
        }

        // Свойство только для чтения - периметр квадрата.
        public double Len
        {
            get
            {
                return side * 4;
            }
        }

        // Метод вывода информации о фигуре.
        public override void Display()
        {
            Console.WriteLine($"Square - side: {side}, center x: {x}, center y: {y}");
        }

        // Свойство - площадь фигуры.
        public override double Area
        {
            get
            {
                return side * side;
            }
        }

        // Конструктор класса.
        public Square(double x, double y, double side)
        {
            this.x = x;
            this.y = y;
            this.side = side;
        }
    }
}
