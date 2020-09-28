using System;

namespace Task07
{
    class Program
    {
        // Method which parses a variable and validates its value
        public static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        // Method which divides the integer and fractional parts of the given number
        public static void DivNum(double x)
        {
            int integer = (int) x;
            double fraction = x - integer;
            Console.WriteLine($"Integer part: {integer}, fraction: {Math.Round(fraction, 3)}.");
        }

        // Method which squares the given number and calculates its square root (if possible)
        public static void PowSqrt(double x)
        {
            double pow2 = x * x;
            Console.Write($"Number in power 2 equals {Math.Round(pow2, 3)}. ");
            if (x > 0)
            {
                double sqrt = Math.Sqrt(x);
                Console.Write($"Square root of number equals {Math.Round(sqrt, 3)}" + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Calculating square root of a number is impossible, number is less than 0." + Environment.NewLine + Environment.NewLine);
            }
        }

        static void Main(string[] args)
        {
            double num;
            while (true)
            {
                Console.Write("Please enter a fractional number or press Enter to exit the program: ");
                if (!Read(out num))
                {
                    Console.WriteLine("Invalid input or 'Enter' pressed");
                    return;
                }
                else
                {
                    DivNum(num);
                    PowSqrt(num);
                }
            }
        }
    }
}
