using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "5 / 3 = " + 5 / 3;
            Console.WriteLine(result);

            result = "5.0 / 3.0 = " + 5.0 / 3.0;
            Console.WriteLine(result);

            result = (5 / 3).ToString();
            Console.WriteLine(result);

            result = 5 / 3 + " = 5/3";
            Console.WriteLine(result);

            Console.WriteLine("Нажмите Enter, чтобы завершить выполнение программы.");
            Console.ReadKey();
        }
    }
}
