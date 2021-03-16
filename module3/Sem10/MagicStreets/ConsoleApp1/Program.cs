using System;
using ClassLibrary;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void PrintNotification()
        {
            Console.WriteLine("One of the lines has a wrong format!");
        }

        static string GenerateRandomString(int len)
        {
            Random rand = new Random();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                char c;
                if (sb.Length == 0) c = (char)rand.Next(65, 91);
                else c = (char)rand.Next(97, 123);

                sb.Append(c);
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            try
            {
                int n;
                do
                {
                    Console.Write("Input the number of streets: ");
                } while (!int.TryParse(Console.ReadLine(), out n));

                string[] lines = File.ReadAllLines("data.txt");
                bool formatIsCorrect = true;

                foreach (var line in lines)
                {
                    string[] paramStrings = line.Split(' ');
                    if (paramStrings.Length < 2)
                    {
                        PrintNotification();
                        formatIsCorrect = false;
                    }

                    for (int i = 1; i < paramStrings.Length; i++)
                    {
                        int dummy;
                        if (!int.TryParse(paramStrings[i], out dummy))
                        {
                            PrintNotification();
                            formatIsCorrect = false;
                            break;
                        }
                    }

                    if (!formatIsCorrect) break;
                }

                Street[] streetsArray = null;

                if (formatIsCorrect)
                {
                    int size = 0;
                    if (n > lines.Length) size = lines.Length;
                    else size = n;

                    streetsArray = new Street[size];

                    for (int i = 0; i < size; i++)
                    {
                        string[] paramStrings = lines[i].Split(' ');

                        string name = paramStrings[0];
                        List<int> houses = new List<int>();

                        for (int j = 1; j < paramStrings.Length; j++) houses.Add(int.Parse(paramStrings[j]));

                        streetsArray[i] = new Street(name, houses.ToArray());
                    }
                } else
                {
                    streetsArray = new Street[n];

                    for (int i = 0; i < streetsArray.Length; i++)
                    {
                        Random rand = new Random();

                        int amount = rand.Next(1, 11);
                        int[] houses = new int[amount];
                        for (int j = 0; j < amount; j++) houses[j] = rand.Next(1, 101);

                        streetsArray[i] = new Street(GenerateRandomString(5), houses);
                    }
                }

                foreach (var street in streetsArray) Console.WriteLine(street);

                string[] streetInfo = new string[streetsArray.Length];

                for (int i = 0; i < streetInfo.Length; i++)
                {
                    streetInfo[i] = $"{streetsArray[i].Name} {string.Join(' ', streetsArray[i].Houses)}";
                }

                File.WriteAllLines("out.txt", streetInfo);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
