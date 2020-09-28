using System;

namespace Task03
{
    class Program
    {
        // Method which parses a variable and validates its value
        public static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        // Method which calculates if a point with specified coordinates belongs to the designated area
        public static bool BelongsToArea(double x, double y)
        {
            double radius = Math.Sqrt(x * x + y * y);
            if (y / radius <= (Math.Sqrt(2) / 2) && y / radius >= -1 && radius <= 2) return true;
            else return false;
        }

        static void Main(string[] args)
        {
            double x, y;
            if (Read(out x) && Read(out y))
            {
                Console.WriteLine(BelongsToArea(x, y));
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
