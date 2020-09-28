using System;
using System.Runtime.CompilerServices;

namespace Task06
{
    class Program
    {
        // Method which parses a variable and validates its value
        public static bool Read(out int x)
        {
            return int.TryParse(Console.ReadLine(), out x);
        }

        // Method which finds a number with minimum value of two last digits
        public static int findMin(int a, int b, int c)
        {
            return (a % 100 <= b % 100 && a % 100 <= c % 100) ? a : ((b % 100 <= a % 100 && b % 100 <= c % 100) ? b : c);
        }

        static void Main(string[] args)
        {
            int num1, num2, num3;
            if (Read(out num1) && Read(out num2) && Read(out num3))
            {
                Console.WriteLine(findMin(num1, num2, num3));
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
