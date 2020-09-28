using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Task02
{
    class Program
    {
        // Method which parses a variable and validates its value
        public static bool Read(out int x)
        {
            return int.TryParse(Console.ReadLine(), out x);
        }

        // Method which inverts given number
        public static void Invert(ref int x)
        {
            // A list containing number's digits
            List<int> digits = new List<int>();

            // Filling the list
            while (x > 0)
            {
                digits.Add(x % 10);
                x /= 10;
            }

            // Changing variable value
            for (int i = 0; i < digits.Count; i++)
            {
                x += digits[i] * (int)Math.Pow(10, (digits.Count - 1 - i));
            }
        }

        static void Main(string[] args)
        {
            int num;
            if (Read(out num))
            {
                Invert(ref num);
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
