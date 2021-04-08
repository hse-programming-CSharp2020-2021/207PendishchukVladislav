using System;
using System.Collections.Generic;
using System.Text;

namespace Task03
{
    [Serializable]
    public class Quadratic
    {
        public double a, b, c;

        public double Discriminant
        {
            get => b * b - 4 * a * c;
        }

        public double X1
        {
            get
            {
                if (Discriminant > 0) return (-1 * b + Math.Sqrt(Discriminant)) / (2 * a);
                else if (Discriminant == 0) return (-1 * b) / (2 * a);
                else return double.NaN;
            }
        }

        public double X2
        {
            get
            {
                if (Discriminant > 0) return (-1 * b - Math.Sqrt(Discriminant)) / (2 * a);
                else if (Discriminant == 0) return (-1 * b) / (2 * a);
                else return double.NaN;
            }
        }

        public Quadratic (double a, double b, double c)
        {
            if (a == 0) throw new ArgumentException("The first coefficient must be non-zero!");

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Quadratic()
        {

        }

        public override string ToString()
        {
            return $"{a}x^2 + {b}x + {c}";
        }
    }
}
