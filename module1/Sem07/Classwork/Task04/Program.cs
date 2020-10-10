using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;

namespace Task04
{
    class Program
    {
        // Метод, валидирующий введенное целочисленное значение.
        static bool Read(out int n)
        {
            return int.TryParse(Console.ReadLine(), out n);
        }

        // Метод, выводящий в консоль главное меню.
        static void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("VOCABULARY KEEPER\n");
            Console.WriteLine("1. Добавить новый словарь");
            Console.WriteLine("2. Добавить новое слово и перевод");
            Console.WriteLine("3. Найти перевод слова");
            Console.WriteLine("4. Игра в карточки");
            Console.WriteLine("5. Выйти");
        }

        // Метод, запускающий меню и осуществляющий развлетление по его опциям.
        static void MenuStart()
        {
            DrawMenu();

            int userResponse;
            bool menuExit;

            do
            {
                menuExit = false;
                Console.Write("\nВведите номер пункта меню, чтобы выбрать: ");
                if (Read(out userResponse) && userResponse <= 5 && userResponse >= 1)
                {
                    switch (userResponse)
                    {
                        case 1:
                            AddNewVocab();
                            menuExit = true;
                            break;
                        case 2:
                            AddNewWord();
                            menuExit = true;
                            break;
                        case 3:
                            FindWord();
                            menuExit = true;
                            break;
                        case 4:
                            PlayGame();
                            menuExit = true;
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                } else menuExit = false;
            } while (menuExit == false);
        }
        
        // Опция меню "Добавить новый словарь".
        static void AddNewVocab()
        {
            Console.Clear();
            Console.Write("Введите имя нового словаря: ");

            string fileName = Console.ReadLine() + ".txt";
            List<string> content = new List<string>();

            while (true)
            {
                Console.Clear();
                Console.Write("Введите слово или введите 0 чтобы закончить ввод: ");

                string[] input = new string[2];

                input[0] = Console.ReadLine();

                if (input[0] == "0")
                {
                    break;
                }
                else
                {
                    Console.Write("\nВведите перевод: ");
                    input[1] = Console.ReadLine();

                    string line = String.Join(" - ", input);
                    
                    content.Add(line);
                }
            }

            File.WriteAllLines(fileName, content);
            MenuStart();
        }

        // Опция меню "Добавить новое слово и перевод".
        static void AddNewWord()
        {
            string fileName;
            Console.Clear();
            try
            {
                fileName = CheckIfExist();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string[] content = new string[2];

            while (true)
            {
                Console.Clear();
                Console.Write("Введите слово или введите 0 чтобы выйти в меню: ");

                string[] input = new string[2];

                input[0] = Console.ReadLine();

                if (input[0] == "0")
                {
                    break;
                }
                else
                {
                    Console.Write("\nВведите перевод: ");
                    input[1] = Console.ReadLine();

                    string line = String.Join(" - ", input);

                    try
                    {
                        using (StreamWriter sw = new StreamWriter(fileName, true))
                        {
                            sw.WriteLine(line);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                }
            }
            MenuStart();
        }

        // Опция "Найти перевод слова".
        static void FindWord()
        {
            string fileName;
            Console.Clear();
            try
            {
                fileName = CheckIfExist();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            string[][] words = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                words[i] = lines[i].Split(" - ");
            }

            while (true)
            {
                Console.Clear();
                Console.Write("Введите искомое слово: ");

                string input = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Совпадения: ");

                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (words[i][j] == input)
                        {
                            Console.WriteLine(lines[i]);
                        }
                    }
                }

                Console.Write("\nПродолжить поиск? (y/n): ");
                string userResponse = Console.ReadLine();

                if (userResponse == "n")
                {
                    break;
                }
            }

            MenuStart();
        }

        // Опция "Игра в карточки".
        static void PlayGame()
        {
            string fileName;
            Console.Clear();
            try
            {
                fileName = CheckIfExist();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            string[][] words = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                words[i] = lines[i].Split(" - ");
            }

            Console.Clear();
            Console.WriteLine("Игра в карточки\n");

            Console.WriteLine("Напишите перевод слов и заработайте очки!");

            Random rand = new Random();
            int playerScore = 0;
            int cpuScore = 0;

            while (true)
            {
                int wordIndex = rand.Next(0, lines.Length);

                Console.Write($"Напишите перевод слова {words[wordIndex][0]}: ");

                string playerGuess = Console.ReadLine();

                if (playerGuess == words[wordIndex][1])
                {
                    playerScore += 1;
                    Console.WriteLine($"ВЕРНО! Ваш счёт: {playerScore}, счёт компьютера: {cpuScore}.");
                }
                else
                {
                    cpuScore += 1;
                    Console.WriteLine($"НЕВЕРНО! Ваш счёт: {playerScore}, счёт компьютера: {cpuScore}. Верный перевод - {words[wordIndex][1]}");
                }

                string userResponse = String.Empty;
                do
                {
                    Console.Write("Хотите продолжить игру? Введите 'нет', чтобы выйти: ");
                    userResponse = Console.ReadLine();
                } while (userResponse != "y" && userResponse != "n");

                if (userResponse == "нет")
                {
                    break;
                }
            }

            Console.Clear();
            Console.Write($"Итоговый счёт: {playerScore}-{cpuScore}.");
            if (playerScore > cpuScore)
            {
                Console.Write(" Вы выиграли!");
            } else if (playerScore < cpuScore)
            {
                Console.Write(" Вы проиграли.");
            }
            else
            {
                Console.Write(" Ничья!");
            }

            Console.Write("\nВведите ваше имя для сохранения результатов: ");

            string name = Console.ReadLine();

            try
            {
                File.AppendAllText("Score.csv", name + ";" + playerScore + ";" + System.DateTime.Now.ToString() + "\n");
            }
            catch (IOException)
            {
                Console.WriteLine("Не удалось записать результат!");
            }

            Console.WriteLine($"\nВаш рекорд - {scoreCheck(name)}");

            Console.WriteLine("\nВыход в меню через 10 секунд...");
            Thread.Sleep(10000);
            MenuStart();
        }

        // Метод проверки предыдущего рекорда игрока.
        static string scoreCheck(string name)
        {
            string[] lines = File.ReadAllLines("Score.csv");

            string[][] words = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                words[i] = lines[i].Split(";");
            }

            int maxScore = int.MinValue;
            int maxScoreLine = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (words[i][0] == name && int.Parse(words[i][1]) > maxScore)
                {
                    maxScore = int.Parse(words[i][1]);
                    maxScoreLine = i;
                }
            }

            return lines[maxScoreLine];
        }

        // Метод проверки существования файла.
        static string CheckIfExist()
        {
            Console.Write("Введите название словаря: ");
            string dictName = Console.ReadLine() + ".txt";

            if (!File.Exists(dictName))
                throw new ArgumentException("Такого словаря не существует");

            return dictName;
        }

        static void Main(string[] args)
        {
            // Вызов меню.
            MenuStart();
        }
    }
}
