using System;
using MyLib;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = 'к', finish = 'ю';
            do
            {
                RusString testString = new RusString(start, finish, 10);
                Console.WriteLine(testString);
                Console.WriteLine(testString.IsPalindrome);
                Console.WriteLine(testString.CountLetter('о'));
                // тестируем неверные входные данные
                try
                {
                    testString = new RusString(start, finish, -11);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Состояние объекта не изменено");// если объект не сформирован
                }
                Console.WriteLine(testString);
                Console.WriteLine(testString.IsPalindrome);
                Console.WriteLine(testString.CountLetter('о'));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }

}
