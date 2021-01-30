using System;

namespace ConsoleApp14
{
    public delegate void VoidOperation();
    public delegate void ItemEvents(int[,] arr);

    static class ArrayOperations
    {
        public static event VoidOperation OnLineEnd;
        public static event ItemEvents NewItemFilled;

        public static void PrintArray(int[,] arr)
        {

            int cntr = 0;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    Console.Write(arr[i, j] + " \t");
                    cntr++;
                    if (cntr % 5 == 0) OnLineEnd?.Invoke();
                }
            }
        }

        public static void FillArray(int[,] arr, int lowerBound = 0, int upperBound = 100)
        {
            Random rand = new Random();
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    arr[i, j] = rand.Next(lowerBound, upperBound);
                    NewItemFilled?.Invoke(arr);
                }
            }
        }

        private static int CalculateArraySum(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    sum += arr[i, j];
                }
            }

            return sum;
        }

        public static void ArraySum(int[,] arr)
        {
            int sum = CalculateArraySum(arr);
            Console.WriteLine("Sum: " + sum);
        }

        public static void ArrayAverage(int[,] arr)
        {
            int sum = CalculateArraySum(arr);
            Console.WriteLine("Average: " + (double)sum / arr.Length);
        }

        public static void ArrayMaximum(int[,] arr)
        {
            int max = int.MinValue;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    if (arr[i, j] > max) max = arr[i, j];
                }
            }

            Console.WriteLine("Maximum value: " + max);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[6, 6];
            ArrayOperations.NewItemFilled += ArrayOperations.ArraySum;
            ArrayOperations.NewItemFilled += ArrayOperations.ArrayAverage;
            ArrayOperations.NewItemFilled += ArrayOperations.ArrayMaximum;

            ArrayOperations.FillArray(arr);

            ArrayOperations.OnLineEnd += () => { Console.WriteLine(); };
            Console.WriteLine();
            ArrayOperations.PrintArray(arr);
        }
    }
}
