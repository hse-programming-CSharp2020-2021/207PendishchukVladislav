using System;
using System.Transactions;

namespace Task05
{
    class Program
    {
        // Method which parses a variable and validates its value
        public static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        // Method which calculated the value of G(x, y) function
        public static double FunctionG(double x)
        {
            if (x <= 0.5) return Math.Sin(Math.PI / 2);
            else return Math.Sin((Math.PI * (x - 1)) / 2);
        }

        static void Main(string[] args)
        {
            double x;
            if (Read(out x))
            {
                Console.WriteLine(Math.Round(FunctionG(x), 3));
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}