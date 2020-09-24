using System;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            string topbot = "*-----------*--------*---------------------*";
            Console.WriteLine(topbot);
            Console.WriteLine("|*Выражение*|*Формат*|**** Изображение ****|");
            Console.WriteLine("|-----------|--------|---------------------|");
            Console.WriteLine("| (5.0/3.0) |  F     | " + (5.0 / 3.0).ToString("F") + "                |");
            Console.WriteLine("| (5.0/3.0) |  F4    | " + (5.0 / 3.0).ToString("F4") + "              |");
            Console.WriteLine("| (5.0/3.0) |  E     | " + (5.0 / 3.0).ToString("E") + "       |");
            Console.WriteLine("| (5.0/3.0) |  E5    | " + (5.0 / 3.0).ToString("E5") + "        |");
            Console.WriteLine("| (5.0/3.0) |  G     | " + (5.0 / 3.0).ToString("G") + "  |");
            Console.WriteLine("| (5.0/3.0) |  G3    | " + (5.0 / 3.0).ToString("G3") + "                |");
            Console.WriteLine("| (5.0/3e10)|  G3    | " + (5.0 / 3e10).ToString("G3") + "            |");
            Console.WriteLine("|(5.0/3e-10)|  G     | " + (5.0 / 3e-10).ToString("G") + "  |");
            Console.WriteLine("| (5.0/3e10)|  G15   | " + (5.0 / 3e10).ToString("G15") + "|");
            Console.WriteLine(topbot);

            Console.WriteLine("Нажмите Enter, чтобы завершить выполнение программы.");
            Console.ReadKey();
        }
    }
}
