using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Task01
{
    class Program
    {
        // Method which finds a three-digit number such that it is a sum of natural numbers 1...n and all of its digits are equal
        public static void FindNum()
        {
            int num = 0;
            int nat = 0;
            List<int> nList = new List<int>();

            while (num < 100 || ((num % 10 != num / 100) || (num % 10 != ((num / 10) % 10))))
            {
                nat += 1;
                num += nat;
                nList.Add(nat);
            }

            Console.WriteLine($"The number is: {num}, {nList[nList.Count - 1]} natural numbers");
            Console.WriteLine($"{nList[0]} + {nList[1]} + {nList[2]} + ... + {nList[nList.Count - 3]} + {nList[nList.Count - 2]} + {nList[nList.Count - 1]}");
        }
        static void Main(string[] args)
        {
            FindNum();
        }
    }
}
