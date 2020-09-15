using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Task02
{
    class Program
    {
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
            int num = Convert.ToInt32(Console.ReadLine());
            Invert(ref num);
            Console.WriteLine(num);
        }
    }
}
