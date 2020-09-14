using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Task01
{
    class Program
    {
        public static double Pow(double x, int powNum)
        {
            for (int i = 0; i < powNum - 1; i++)
            {
                x *= x;
            }

            return x;
        }

        public static double CalculateFunc(double x)
        {
            double _1stNum = 0, _2ndNum = 0, _3rdNum = 0;
            for (int i = 0; i < 12; i++)
            {
                _1stNum += Pow(x, 4);
            }

            for (int i = 0; i < 9; i++)
            {
                _2ndNum += Pow(x, 3);
            }

            for (int i = 0; i < 3; i++)
            {
                _3rdNum += Pow(x, 2);
            }

            return _1stNum + _2ndNum - _3rdNum + x + x - 4;
        }

        public static bool Read(out double x)
        {
            return double.TryParse(Console.ReadLine(), out x);
        }

        static void Main(string[] args)
        {
            double x;
            while (true)
            {
                Console.Write("Please input a value or press Enter to exit the program: ");
                if (!Read(out x))
                {
                    Console.WriteLine("Invalid input or 'Enter' pressed.");
                    return;
                }
                else
                {
                    Console.WriteLine($"F(x) function value equals {CalculateFunc(x)}.");
                }
            }
        }
    }
}
