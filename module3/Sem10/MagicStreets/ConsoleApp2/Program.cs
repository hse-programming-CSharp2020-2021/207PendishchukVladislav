using System;
using ClassLibrary;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"..\..\..\..\ConsoleApp1\bin\Debug\netcoreapp3.1\out.txt");

                Street[] streets = new Street[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] paramStrings = lines[i].Split(' ');
                    string name = paramStrings[0];

                    int[] houses = new int[paramStrings.Length - 1];
                    for (int j = 1; j < paramStrings.Length; j++)
                    {
                        houses[j - 1] = int.Parse(paramStrings[j]);
                    }

                    streets[i] = new Street(name, houses);
                }

                List<Street> magicStreets = new List<Street>();
                foreach (var street in streets)
                {
                    if (~street % 2 != 0 && !street) magicStreets.Add(street);
                }

                Console.WriteLine("Magic streets: ");
                foreach (var ms in magicStreets) Console.WriteLine(ms);
                if (magicStreets.Count == 0) Console.WriteLine("No magic streets are present!");
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
