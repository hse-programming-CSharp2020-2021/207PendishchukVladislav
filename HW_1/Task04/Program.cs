using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            double U = Convert.ToDouble(Console.ReadLine());
            double R = Convert.ToDouble(Console.ReadLine());
            double amp = U / R;
            double pow = (U * U) / R;
            Console.WriteLine("Amperage: " + amp + "; power: " + pow);
        }
    }
}
