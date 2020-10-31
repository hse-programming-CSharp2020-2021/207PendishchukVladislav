using System;

namespace Task07
{
    class Program
    {
        // Филиалы.
        static string[] Filials = { "Западный", "Центральный", "Восточный" };

        // Кварталы.
        static string[] Kvartal = { "I", "II", "III", "IV" };

        // Кол-во продаж.
        static int[,] auto = { { 20, 24, 25 }, // I
            { 21, 20, 18 }, // II
            { 23, 27, 24 }, // III
            { 22, 19, 20 }  // IV
        };


        /// <summary>
        /// Метод вывода таблицы в консоль.
        /// </summary>
        static void PrintTable()
        {
            // Вывод шапки.
            Console.Write("Квартал\\филиал".PadRight(15));
            foreach (var dep in Filials)
            {
                Console.Write(dep.PadRight(15));
            }

            Console.WriteLine();

            // Вывод строк таблицы.
            for (int i = 0; i < Kvartal.Length; i++)
            {
                Console.Write(Kvartal[i].PadRight(15));
                for (int k = 0; k < auto.GetLength(1); k++)
                {
                    Console.Write(auto[i, k].ToString().PadRight(15));
                }

                Console.WriteLine();
            }
        }


        /// <summary>
        /// Метод вычисления кол-ва проданных авто за весь год всеми филиалами.
        /// </summary>
        /// <returns> Кол-во проданных авто за весь год всеми филиалами. </returns>
        static int Sum()
        {
            int sum = 0;

            // Вычисление суммы.
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                for (int k = 0; k < auto.GetLength(1); k++)
                {
                    sum += auto[i,k];
                }
            }

            return sum;
        }


        /// <summary>
        /// Метод нахождения индексов максимального кол-во проданных авто.
        /// </summary>
        /// <returns> Индексы максимального кол-во проданных авто. </returns>
        static int[] MaxIndices()
        {
            int[] maxIndices = new int[2];
            int max = 0;
            
            // Нахождение индексов.
            for (int i = 0; i < auto.GetLength(0); i++)
            {
                for (int k = 0; k < auto.GetLength(1); k++)
                {
                    if (auto[i, k] > max)
                    {
                        maxIndices[0] = i;
                        maxIndices[1] = k;
                        max = auto[i, k];
                    }
                }
            }

            return maxIndices;
        }


        /// <summary>
        /// Метод нахождения наиболее успешного квартала по числу продаж.
        /// </summary>
        /// <returns> Номер квартала-строки (от 0 до 3) и число продаж за квартал. </returns>
        static int[] BestQuarter()
        {
            int maxValue = int.MinValue;
            int bestQuarter = 0;

            for (int i = 0; i < Kvartal.Length; i++)
            {
                int sum = 0;
                for (int k = 0; k < auto.GetLength(1); k++)
                {
                    sum += auto[i, k];
                }

                if (sum > maxValue)
                {
                    maxValue = sum;
                    bestQuarter = i;
                }
            }

            int[] bestQuarterInfo = {bestQuarter, maxValue};

            return bestQuarterInfo;
        }


        /// <summary>
        /// Метод нахождения наиболее успешного филиала по итогам за один квартал.
        /// </summary>
        /// <param name="quarter"> Номер квартала (от 1 до 4). </param>
        /// <returns> Индексы наибольшего показателя. </returns>
        static int[] MaxInQuarter(int quarter)
        {
            int[] maxIndices = new int[2];
            int max = 0;
            maxIndices[0] = quarter - 1;

            for (int k = 0; k < auto.GetLength(1); k++)
            {
                if (auto[quarter - 1, k] > max)
                {
                    maxIndices[1] = k;
                    max = auto[quarter - 1, k];
                }
            }

            return maxIndices;
        }


        /// <summary>
        /// Метод вывода информации о продажах.
        /// </summary>
        static void PrintInfo()
        {
            Console.WriteLine("\n======================= ИНФОРМАЦИЯ =======================");
            Console.WriteLine("Всего авто продано: " + Sum());
            Console.WriteLine();
            for (int i = 0; i < Kvartal.Length; i++)
            {
                Console.WriteLine("В квартале " + Kvartal[i] + " больше всего продано филиалом " + Filials[MaxInQuarter(i + 1)[1]] + " - " + auto[MaxInQuarter(i + 1)[0], MaxInQuarter(i + 1)[1]]);
            }

            Console.WriteLine();
            int[] maxIndices = MaxIndices();
            Console.WriteLine("Больше всего продано в квартале " + Kvartal[maxIndices[0]] + " филиалом " + Filials[maxIndices[1]] + " - " + auto[maxIndices[0], maxIndices[1]]);
            int[] bestQuarterInfo = BestQuarter();
            Console.WriteLine("Наиболее успешный квартал по всем филиалам в общем - квартал " + Kvartal[bestQuarterInfo[0]] + ", продано " + bestQuarterInfo[1] + " авто");
        }

        static void Main(string[] args)
        {
            PrintTable();
            PrintInfo();
        }
    }
}
