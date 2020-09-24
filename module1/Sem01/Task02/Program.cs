using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя:");
            string name = Console.ReadLine();
            Console.WriteLine($"Здравствуйте, {name}!");

            Console.WriteLine("Нажмите Enter, чтобы завершить выполнение программы.");
            Console.ReadKey();
        }
    }
}
