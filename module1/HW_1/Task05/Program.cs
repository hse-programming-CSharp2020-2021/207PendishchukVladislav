using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double c1 = Convert.ToDouble(Console.ReadLine());
            double c2 = Convert.ToDouble(Console.ReadLine());
            double hyp = Math.Sqrt(c1 * c1 + c2 * c2);
            Console.WriteLine(hyp);
        }
    }
}
