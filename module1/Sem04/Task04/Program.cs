using System;

namespace Task04
{
    class Program
    {
        static bool Read(out int x)
        {
            return int.TryParse(Console.ReadLine(), out x);
        }


        static void Main(string[] args)
        {
            Random rand = new Random();
            int m, n;
            Console.WriteLine("Введите размерность матрицы A (m x n):");
            if (Read(out m) && Read(out n))
            {
                int[] matrix = new int[m * n];
                for (int i = 0; i < (m * n); i++)
                {
                    matrix[i] = rand.Next(-20, 21);
                }

                for (int i = 0; i < (m * n); i++)
                {
                    if ((i + 1) % n == 0)
                    {
                        Console.Write($"\t{matrix[i]}" + Environment.NewLine);
                    }
                    else if ((i + 1) % n == 1)
                    {
                        Console.Write($"{matrix[i]}");
                    }
                    else
                    {
                        Console.Write($"\t{matrix[i]}");
                    }
                }
            }
            else
            {
                Console.WriteLine("INVALID INPUT");
            }
        }
    }
}
