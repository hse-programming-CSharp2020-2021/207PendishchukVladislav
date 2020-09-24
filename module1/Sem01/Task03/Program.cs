using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите вашу фамилию: ");
            string surname = Console.ReadLine();
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите ваше отчество: ");
            string patron = Console.ReadLine();

            Console.WriteLine($"Фамилия: {surname}");
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Отчество: {patron}");

            Console.WriteLine("Нажмите Enter, чтобы завершить выполнение программы.");
            Console.ReadKey();
        }
    }
}
