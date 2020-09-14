using System;

namespace Task05
{
    class Program
    {
        public static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        public static string TriangleIneq(double a, double b, double c)
        {
            double maxnum = Math.Max(a, Math.Max(b, c));
            double sum = (a + b + c) - maxnum;
            return (maxnum < sum) ? "Inequality holds." : "Inequality does not hold.";
        }
        static void Main(string[] args)
        {
            double a, b, c;
            Console.Write("Please input three numbers: ");
            string output = (Read(out a) && Read(out b) && Read(out c)) ? TriangleIneq(a, b, c) : "Invalid input.";
            Console.WriteLine(output + Environment.NewLine);
        }
    }
}
