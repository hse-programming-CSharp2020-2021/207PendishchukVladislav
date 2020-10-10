using System;
using System.IO;
using System.Linq;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройки ввода\вывода.
            const string inputDir = "input.txt";
            const string outputDir = "output.txt";

            // Чтение файла.
            string content = File.ReadAllText(inputDir);

            // Формирование массива А.
            int[] A = Array.ConvertAll(content.Split(' '), s => int.Parse(s));

            // Формирование массива L.
            int[] L = new int[A.Length];
            for (int i = 0; i < L.Length; i++) L[i] = 1;
            for (int i = 0; i < A.Length; i++)
            {
                int power = 0;
                while (L[i] < A[i])
                {
                    L[i] *= 2;
                    power += 1;
                }

                L[i] = (int) Math.Pow(2, power - 1);
            }

            // Формирование вывода.
            string output = string.Join(' ', L.Select(element => element.ToString()).ToArray());

            // Запись в файл.
            File.WriteAllText(outputDir, output);
        }
    }
}