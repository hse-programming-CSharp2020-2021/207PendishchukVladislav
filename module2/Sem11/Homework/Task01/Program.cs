using System;
using MyLib;

namespace Task01
{
    public class Program
    {
        public static void Main()
        {
            Matrix newMatrix = new Matrix();
            int rank; // Порядок матрицы
            do
            { // цикл повторения решений
                try
                {
                    rank = newMatrix.GetIntValue("Введите порядок матрицы: ");
                    newMatrix.matrix = newMatrix.UnitMatr(rank);
                    newMatrix.MatrPrint(newMatrix.matrix);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Для завершения программы нажмите ESC");
                    continue;
                }
                catch (ArgumentNullException e1)
                {
                    Console.WriteLine("Строка имеет значение null.");
                    Console.WriteLine("Для завершения программы нажмите ESC");
                    continue;
                }
                catch (FormatException e2)
                {
                    Console.WriteLine("Строка с значением имеет неверный формат.");
                    Console.WriteLine("Для завершения программы нажмите ESC");
                    continue;
                }
                catch (OverflowException e3)
                {
                    Console.WriteLine("Введённое значение вызывает переполнение.");
                    Console.WriteLine("Для завершения программы нажмите ESC");
                    continue;
                }

                Console.WriteLine("Для завершения программы нажмите ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        } // Main( )
    }

}
