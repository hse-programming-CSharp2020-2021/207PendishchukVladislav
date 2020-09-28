using System;
using System.Runtime.ExceptionServices;

namespace Task02
{
    class Program
    {
        static bool Read(out int x)
        {
            return int.TryParse(Console.ReadLine(), out x);
        }

        static int Convert(int x, int system)
        {
            int res = 0;
            int decCntr = 0;
            while (x > 0)
            {
                res += (x % system) * (int)Math.Pow(10, decCntr);
                decCntr += 1;
                x /= system;
            }

            return res;
        }


        static void Main(string[] args)
        {
            int n;
            Console.Write("Введите n: ");
            if (Read(out n))
            {
                Console.WriteLine($"BIN: {Convert(n, 2)}");
                Console.WriteLine($"OCT: {Convert(n, 8)}");
                Console.WriteLine($"HEX: {Convert(n, 16)}");
            }
            else
            {
                Console.WriteLine("INVALID INPUT");
            }
        }
    }
}
