using System;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = new string[3];
            for (int i = 0; i < 3; i++) str[i] = Console.ReadLine();
            for (int i = 0; i < 3; i++) Console.WriteLine("-" + str[i] + "-");
        }
    }
}
