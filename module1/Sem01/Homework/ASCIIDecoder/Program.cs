using System;

namespace ASCIIDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            int code = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((char)code);
        }
    }
}
