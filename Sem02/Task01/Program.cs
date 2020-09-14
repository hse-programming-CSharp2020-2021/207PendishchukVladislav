using System;

namespace Task01
{
    class Program
    {
        public static string MarkInterpret(int x)
        {
            switch (x)
            {
                case 1:
                case 2:
                case 3:
                    return "Неудовлетворительно";
                case 4:
                case 5:
                    return "Удовлетворительно";
                case 6:
                case 7:
                    return "Хорошо";
                case 8:
                case 9:
                case 10:
                    return "Отлично";
                default:
                    return "INVALID MARK";
            }
        }
        static void Main(string[] args)
        {
            int mark;
            bool parse = int.TryParse(Console.ReadLine(), out mark);
            if (!parse)
            {
                Console.WriteLine("ERROR");
                return;
            }
            else
            {
                Console.WriteLine(MarkInterpret(mark));
            }
        }
    }
}
