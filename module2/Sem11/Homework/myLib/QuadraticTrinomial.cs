using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class QuadraticTrinomial
    {
        // коэффициенты при степенях 2,1 и 0
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public QuadraticTrinomial(double a, double b, double c)
        {
            A = a; B = b; C = c;
        }
        // значение квадратного трёхчлена в точке x0
        public double ValueInX(double x0)
        {
            return A * x0 * x0 + B * x0 + C;
        }

        // метод возвращает частное от деления значения в точке x0 
        // квадратного трёхчлена на значение в точке x0 квадратного
        // трёхчлена, переданного в качестве параметра
        public double Division(QuadraticTrinomial another, double x0)
        {
            double div = 1;
            if (another.ValueInX(x0) == 0)
                throw new ArgumentException("Полином в знаменателе принимает нулевое значение.");
            else div = ValueInX(x0) / another.ValueInX(x0);
            return div;
        }
    }

}
