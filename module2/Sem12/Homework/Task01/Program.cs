using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = IntegerParse.GetIntValue("Введите N: ");
            UserString digits = new UserString(N, '0', '9');
            Console.WriteLine(digits.objectString);
            digits.MoveOff("2468");
            Console.WriteLine(digits.objectString);
        }
    }
}
