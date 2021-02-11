using System;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Введите число: ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

            LinkedList<int> digitsLinked = new LinkedList<int>();
            Stack<int> digitsStack = new Stack<int>();

            while (n > 0)
            {
                int digit = n % 10;
                digitsLinked.AddFirst(digit);
                digitsStack.Push(digit);
                n /= 10;
            }

            foreach (var digit in digitsLinked)
                Console.Write(digit + " \t");

            Console.WriteLine();

            foreach (var digit in digitsStack)
                Console.Write(digit + " \t");
        }
    }
}
