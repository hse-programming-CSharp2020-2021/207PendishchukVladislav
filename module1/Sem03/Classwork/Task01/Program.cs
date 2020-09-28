using System;

namespace Task01
{
    class Program
    {
        // Метод, переводящий оценку в баллах десятибалльной шкалы в аттестационную шкалу.
        public static void Interpret(int mark)
        {
            switch (mark)
            {
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("Неудовлетворительно");
                    break;
                case 4:
                case 5:
                    Console.WriteLine("Удовлетворительно");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Хорошо");
                    break;
                case 8:
                case 9:
                case 10:
                    Console.WriteLine("Отлично");
                    break;
            }
        }

        static void Main(string[] args)
        {
            int num;
            int.TryParse(Console.ReadLine(), out num);
            Interpret(num);
        }
    }
}
