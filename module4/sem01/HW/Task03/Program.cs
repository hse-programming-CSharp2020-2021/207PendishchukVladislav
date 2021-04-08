using System;


namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Processing.WriteFile("equation.ser", 8);

            Console.WriteLine("Выполнена запись в режиме сериализации.");
            Console.WriteLine("Для вывода на экран нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("В файле сведения о следующих уравнениях: ");

            Processing.Process("equation.ser", new QDelegate(Processing.PrintEq));

            Console.WriteLine("Для решения уравнений нажмите любую клавишу.");
            Console.ReadKey(true);
            Console.WriteLine("\r\nРешения уравнений с вещественными корнями: ");

            Processing.Process("equation.ser", new QDelegate(Processing.SolutionReal));

            Console.WriteLine("Для завершения работы нажмите ENTER.");
            Console.ReadLine();
        }
    }
}
