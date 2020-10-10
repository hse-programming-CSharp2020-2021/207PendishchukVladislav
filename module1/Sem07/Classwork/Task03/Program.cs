using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    // Метод, генерирующий содержимое файла, записывающий его в файл и выводящий его в консоль.
    static void generateFile(int linesAmount, string fileName, Encoding enc)
    {
        List<string> content = new List<string>();
        Random rand = new Random();
        for (int i = 0; i < linesAmount; i++)
        {
            int lineLength = rand.Next(20, 51);
            string line = string.Empty;
            for (int j = 0; j < lineLength; j++)
            {
                line += (char)rand.Next('А', 'Я');
            }

            int dotProb = rand.Next(0, 2);
            if (dotProb == 1) line += ".";

            content.Add(line);

            line = string.Empty;
        }

        Console.WriteLine("Сгенерированный текст:");
        foreach (var line in content)
        {
            Console.WriteLine(line);
        }

        File.WriteAllLines(fileName, content, enc);
    }

    // Метод, удаляющий точки в концах предложений в файле при их наличии.
    static void deleteDots(string fileName, Encoding enc)
    {
        string[] content = File.ReadAllLines(fileName, enc);

        for (int i = 0; i < content.Length; i++)
        {
            if (content[i].EndsWith('.')) content[i] = content[i].Substring(0, content[i].Length - 1);
        }

        Console.WriteLine("\nИзменённый текст:");
        foreach (var line in content)
        {
            Console.WriteLine(line);
        }
    }

    static void Main()
    {
        // Кол-во предложений в файле.
        const int lines = 6;

        // Имя файла.
        string fileName = "dialog.txt";

        // Кодировка файла.
        Encoding enc = Encoding.UTF8;

        // Генерация файла.
        generateFile(lines, fileName, enc);

        // Удаление точек в файле.
        deleteDots(fileName, enc);

        Console.ReadKey();
    }
}