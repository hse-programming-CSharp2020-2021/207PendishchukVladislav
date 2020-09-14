using System;
using System.Net;

namespace Task02
{
    class Program
    {
        public static int SortMax(int x)
        {
            int tmp;
            int _1stNum = x / 100;
            int _2ndNum = (x / 10) % 10;
            int _3rdNum = x % 10;
            if (_2ndNum < _1stNum)
            {
                tmp = _1stNum;
                _1stNum = _2ndNum;
                _2ndNum = tmp;
            }
            if (_3rdNum < _2ndNum)
            {
                tmp = _2ndNum;
                _2ndNum = _3rdNum;
                _3rdNum = tmp;

                if (_2ndNum < _1stNum)
                {
                    tmp = _1stNum;
                    _1stNum = _2ndNum;
                    _2ndNum = tmp;
                }
            }

            return (_3rdNum * 100 + _2ndNum * 10 + _1stNum);
        }

        public static bool Read(out int x)
        {
            return int.TryParse(Console.ReadLine(), out x);
        }
        static void Main(string[] args)
        {
            int p;
            while (true)
            {
                Console.Write("Please input a 3-digit number or press Enter to exit the program: ");
                if (!Read(out p) || p < 100 || p > 999)
                {
                    Console.WriteLine("Invalid input or 'Enter' pressed.");
                    return;
                }
                else
                {
                    Console.WriteLine(SortMax(p));
                }
            }
        }
    }
}
