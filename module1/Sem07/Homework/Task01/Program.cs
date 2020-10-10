using System;
using System.IO;
using System.Linq;

namespace Task01
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
            bool[] L = new bool[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= 0) L[i] = true;
                else L[i] = false;
            }

            // Формирование вывода.
            string output = string.Join(' ', L.Select(element => element.ToString()).ToArray());

            // Запись в файл.
            File.WriteAllText(outputDir, output);
        }
    }
}
