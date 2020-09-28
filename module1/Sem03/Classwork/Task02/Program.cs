using System;

namespace Task02
{
    class Program
    {
        // Метод, возвращающий истинностное значение выражения !(p & q) & !(p | !q) для данных значений атомов p, q.
        public static bool Function(bool p, bool q)
        {
            return !(p & q) & !(p | !q);
        }

        static void Main(string[] args)
        {
            bool q, res;
            bool p = true;
            Console.WriteLine(" p \t q \t F");
            do
            {
                q = true;
                do
                {
                    res = Function(p, q);
                    Console.WriteLine($"{Convert.ToInt16(p)}\t{Convert.ToInt16(q)}\t{Convert.ToInt16(res)}");
                    q = !q;
                } while (!q);
                p = !p;
            } while (!p);
        }
    }
}
