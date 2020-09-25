using System;

namespace Task08
{
    class Program
    {
        // Метод, выводящий все тройки чисел a, b и c из интервала [1, 20], для который a^2 + b^2 = c^2.
        static void FindNums()
        {
            for (int i = 1; i <= 20; i++)
            {
                for (int j = 1; j <= 20 && j != i; j++)
                {
                    if (i * i + j * j >= 1 && i * i + j * j <= 20) Console.WriteLine($"{i}, {j}, {i * i + j * j}");
                }
            }
        }

        static void Main(string[] args)
        {
            FindNums();
        }
    }
}