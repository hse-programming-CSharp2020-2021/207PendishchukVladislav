using System;

namespace Task04
{
    class Program
    {
        public static bool Read(out int x)
        {
            return int.TryParse(Console.ReadLine(), out x);
        }

        public static void Invert(int x)
        {
            int _1stDigit = x / 1000, _2ndDigit = (x / 100) % 10, _3rdDigit = (x / 10) % 10, _4thDigit = x % 10;
            Console.Write("The inverted number is " + _4thDigit);
            Console.Write(_3rdDigit);
            Console.Write(_2ndDigit);
            Console.Write(_1stDigit + "." + Environment.NewLine);
        }

        static void Main(string[] args)
        {
            int num;
            while (true)
            {
                Console.Write("Please input a four-digit number or press Enter to exit the program: ");
                if (!Read(out num) || num < 1000 || num > 9999)
                {
                    Console.WriteLine("Invalid input or 'Enter' pressed.");
                    return;
                }
                else
                {
                    Invert(num);
                }
            }
        }
    }
}