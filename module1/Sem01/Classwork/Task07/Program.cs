using System;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum, secondNum;
            Console.Write("Введите первое целое число: ");
            // Конвертация при помощи Parse().
            firstNum = int.Parse(Console.ReadLine());

            Console.Write("Введите второе целое число: ");
            // Конвертация при помощи TryParse().
            int.TryParse(Console.ReadLine(), out secondNum);

            Console.WriteLine($"Сумма чисел: {firstNum + secondNum}");

            Console.WriteLine("Нажмите Enter, чтобы завершить выполнение программы.");
            Console.ReadKey();
        }
    }
}
