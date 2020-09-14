using System;
using System.Transactions;

namespace Task03
{
    class Program
    {
        public static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        public static void Linear(double b, double c)
        {
            switch (b)
            {
                case 0:
                    switch (c)
                    {
                        case 0:
                            Console.WriteLine("Infinite amount of roots.");
                            break;
                        default:
                            Console.WriteLine("No roots of equation.");
                            break;
                    }
                    break;
                default:
                    double root = (-c) / b;
                    Console.WriteLine($"The root of the equation equals {root}.");
                    break;
            }
        }

        public static void Quadratic(double a, double b, double c)
        {
            double dis = b * b - 4 * a * c;
            int numswitch = (dis >= 0) ? ((dis == 0) ? 0 : 1) : -1;
            switch (numswitch)
            {
                case -1:
                    Console.WriteLine("Two complex roots exist.");
                    double real = Math.Round(((-b) / (2 * a)), 3);
                    double im = Math.Round(((Math.Sqrt(Math.Abs(dis))) / (2 * a)), 3);
                    Console.WriteLine($"Root x1 equals {real}+{im}i");
                    Console.WriteLine($"Root x2 equals {real}-{im}i");
                    break;
                case 0:
                    Console.WriteLine("One root exists.");
                    double root = Math.Round(((-b) / (2 * a)), 3);
                    Console.WriteLine($"Root x equals {root}");
                    break;
                case 1:
                    Console.WriteLine("Two roots exist.");
                    double x1 = Math.Round((((-1 * b) + Math.Sqrt(dis)) / (2 * a)), 3);
                    double x2 = Math.Round((((-1 * b) - Math.Sqrt(dis)) / (2 * a)), 3);
                    Console.WriteLine($"Root x1 equals {x1}");
                    Console.WriteLine($"Root x2 equals {x2}");
                    break;
            }
        }
        static void Main(string[] args)
        {
            double a, b, c;
            Console.Write("Please input the coefficients: ");
            bool readCheck_a = Read(out a);
            bool readCheck_b = Read(out b);
            bool readCheck_c = Read(out c);
            bool readCheck = readCheck_a && readCheck_b && readCheck_c;
            switch (readCheck)
            {
                case true:
                    switch (a)
                    {
                        case 0:
                            Linear(b, c);
                            break;
                        default:
                            Quadratic(a, b, c);
                            break;
                    }
                    break;
                case false:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
