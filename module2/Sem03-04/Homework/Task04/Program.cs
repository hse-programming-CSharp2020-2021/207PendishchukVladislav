using System;

namespace Task04
{
    public class HexNumber
    {
        // Целое неотрицательное число.
        private uint number;

        // Шестнадцатеричное представление числа.
        private char[] hexView;

        // Конструктор класса HexNumber общего вида.
        public HexNumber(uint n)
        {
            number = n;
            hexView = series(n);
        }

        // Консруктор умолчания.
        public HexNumber() : this(0) { }

        // Свойство - десятичное целое.
        public uint Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                hexView = series(value);
            }
        }

        // Свойство - массив символов-цифр.
        public char[] HexView
        {
            get { return hexView; }
        }

        // Свойство - строковое представление (шестнадцатеричное) числа.
        public string Record
        {
            get
            {
                string str = new String(hexView);
                return "0x" + str;
            }
        }

        // Метод, возвращающий массив шестнадцатеричных цифр числа-параметра. 
        char[] series(uint num)
        {
            int arLen = num == 0 ? 1 : (int)Math.Log(num, 16) + 1;
            char[] res = new char[arLen];
            for (int i = arLen - 1; i >= 0; i--)
            {
                uint temp = (uint)(num % 16);
                if (temp >= 0 & temp <= 9) res[i] = (char)('0' + temp);
                else res[i] = (char)('A' + temp % 10);
                num /= 16;
            }
            return res;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            HexNumber hex;
            hex = new HexNumber(0);
            uint number;
            while (true)
            {
                do Console.Write("Введите целое неотрицательное число:  ");
                while (!uint.TryParse(Console.ReadLine(), out number));

                hex.Number = number;
                Console.WriteLine($"Свойство Number: {hex.Number}");
                Console.Write("Шестнадцатеричные цифры числа: ");

                foreach (char h in hex.HexView) Console.Write($"{h}");

                Console.WriteLine($"{Environment.NewLine}Шестнадцатеричная запись: {hex.Record}");
                Console.WriteLine("Для выхода нажмите клавишу ESC");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            }
        }
    }
}
