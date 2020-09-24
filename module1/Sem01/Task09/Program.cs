using System;

namespace Task09
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum, secondNum;
            Console.Write("Введите первое число: ");
            double.TryParse(Console.ReadLine(), out firstNum);


            Console.Write("Введите второе число: ");
            double.TryParse(Console.ReadLine(), out secondNum);

            double sum = firstNum - (int)firstNum + secondNum - (int)secondNum;

            Console.WriteLine($"Сумма: {sum}");

            Console.WriteLine("Нажмите Enter, чтобы завершить выполнение программы.");
            Console.ReadKey();
        }
    }
}
