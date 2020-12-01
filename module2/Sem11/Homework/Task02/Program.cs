using System;
using MyLib;

namespace Task02
{
    class Program
    {
        static void Main()
        {
            GeomProgr geomProgrObj;
            bool flag;
            int b, q;
            do
            {
                flag = false;
                try
                {
                    Console.Write("Введите начальный член прогрессии: ");
                    b = int.Parse(Console.ReadLine());
                    Console.Write("Введите знаменатель прогрессии: ");
                    q = int.Parse(Console.ReadLine());
                    geomProgrObj = new GeomProgr(b, q);

                    while (true)
                    {
                        Console.Write("Введите номер от 0 или нажмите Enter, чтобы выйти: ");
                        string nStr = Console.ReadLine();

                        if (nStr == "") break;

                        if (nStr == "") return;
                        int n = int.Parse(nStr);

                        Console.WriteLine($"{n + 1}-ый член прогрессии: {geomProgrObj[n]}");
                        Console.WriteLine($"Сумма {n + 1} членов прогрессии: {geomProgrObj.ProgrSum(n)}");
                    }
                }
                catch (ArgumentException e)
                {
                    flag = true;
                    if (e.Message != String.Empty) Console.WriteLine(e.Message);
                    else Console.WriteLine("Ошибка - неверное значение.");
                }
                catch (IndexOutOfRangeException e)
                {
                    flag = true;
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    flag = true;
                    Console.WriteLine("Строка с значением имеет неверный формат.");
                }
            } while (flag);
        }

    }
}
