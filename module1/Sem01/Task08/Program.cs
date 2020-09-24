 using System;

namespace Task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum, secondNum;
            Console.Write("Введите первое целое число: ");
            int.TryParse(Console.ReadLine(), out firstNum);
            

            Console.Write("Введите второе целое число: ");
            int.TryParse(Console.ReadLine(), out secondNum);


            Console.WriteLine($"(Х - У) = {firstNum - secondNum}");
            Console.WriteLine($"(Х * У) = {firstNum * secondNum}");
            Console.WriteLine($"(Х / У) = {firstNum / secondNum}");
            Console.WriteLine($"(Х % У) = {firstNum % secondNum}");
            Console.WriteLine($"(Х << У) = {firstNum << secondNum}");
            Console.WriteLine($"(Х >> У) = {firstNum >> secondNum}");

            Console.WriteLine("Нажмите Enter, чтобы завершить выполнение программы.");
            Console.ReadKey();
        }
    }
}
