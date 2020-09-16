using System;
using System.Transactions;

namespace Task04
{
    class Program
    {
        // Method which parses a variable and validates its value
        public static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        // Method which calculated the value of G(x, y) function
        public static double FunctionG(double x, double y)
        {
            if (x < y && x > 0) return x + Math.Sin(y);
            else if (x > y && x < 0) return y - Math.Cos(x);
            else return 0.5 * x * y;
        }

        static void Main(string[] args)
        {
            double x, y;
            if (Read(out x) && Read(out y))
            {
                Console.WriteLine(Math.Round(FunctionG(x, y), 3));
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
