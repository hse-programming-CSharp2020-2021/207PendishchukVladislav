using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Net.Mime;

namespace Task06
{
    class Program
    {
        // Method which parses a variable and validates its value
        public static void Read(out decimal x, out int y)
        {
            Console.Write("Please input the budget value: ");
            bool parsedec = decimal.TryParse(Console.ReadLine(), out x);
            if (!parsedec || x < 0)
            {
                Console.WriteLine("Invalid budget value or 'Enter' pressed");
                y = 0;
                Environment.Exit(1);
            }
            else
            {
                Console.Write("Please input the percentage: ");
                bool parseint = int.TryParse(Console.ReadLine(), out y);
                if (!parseint || y < 0)
                {
                    Console.WriteLine("INVALID PERCENTAGE VALUE");
                    Environment.Exit(1);
                }
            }
        }

        // Method which calculates a sum based on given budget and percentage
        public static decimal CalculateSum(decimal x, int y)
        {
            return (x * ((decimal)y / 100));
        }

        // Method for forming an output using a currency format
        public static void Output(decimal x)
        {
            CultureInfo us = new CultureInfo("us-US");
            Console.WriteLine("Sum spent on video games: " + x.ToString("C", us) + Environment.NewLine);
        }

        static void Main(string[] args)
        {
            decimal budget;
            int percent;
            while (true)
            {
                Console.WriteLine("Press Enter to exit the program");
                Read(out budget, out percent);
                Output(CalculateSum(budget, percent));
            }
        }
    }
}
