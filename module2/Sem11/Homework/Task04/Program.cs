using System;
using MyLib;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticTrinomial func1 = new QuadraticTrinomial(2, 3, 7);
            QuadraticTrinomial func2 = new QuadraticTrinomial(1, -5, 6);

            double[] values = {1, -3, 3, 2, 7, 100, 0};

            foreach (var num in values)
            {
                try
                {
                    Console.WriteLine($"Результат для x = {num}: {func1.Division(func2, num)}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
