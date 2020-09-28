using System;
using System.Threading.Channels;

namespace Task01
{
    class Program
    {
        public static int[] RandomArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(-50, 51);
            }

            return array;
        }

        public static void ReplaceMax(int num, ref int[] array)
        {
            int max = -51;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == max) array[i] = num;
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int max = Convert.ToInt32(Console.ReadLine());

            int[] a = RandomArray(n);
            Console.WriteLine("Generated array: ");
            PrintArray(a);

            ReplaceMax(max, ref a);
            Console.WriteLine("Replaced maximums:");
            PrintArray(a);
        }
    }
}
