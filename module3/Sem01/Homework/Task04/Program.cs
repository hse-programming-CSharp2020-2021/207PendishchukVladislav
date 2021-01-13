using System;
using Task04ClassLibrary;

namespace Task04
{
    class Program
    {
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == '*') Console.ForegroundColor = ConsoleColor.Red;
                    else if (matrix[i, j] == '+') Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(matrix[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Robot robot = new Robot();
            int n;
            do
            {
                Console.Write("Введите размер поля n (поле n на n): ");
            } while (!int.TryParse(Console.ReadLine(), out n));

            char[,] fieldMatrix = new char[n + 2, n + 2];

            Console.Clear();

            fieldMatrix[0,0] = '╔';
            for (int i = 1; i < n + 1; i++) fieldMatrix[0, i] = '═';
            fieldMatrix[0, n + 1] = '╗';

            for (int i = 1; i < n + 1; i++)
            {
                fieldMatrix[i, 0] = '║';
                for (int j = 1; j < n + 1; j++)
                {
                    if (i == n - robot.Y && j == robot.X + 1)
                    {
                        fieldMatrix[i, j] = '*';
                    }
                    else fieldMatrix[i, j] = ' ';
                }
                fieldMatrix[i, n + 1] = '║';
            }

            fieldMatrix[n + 1, 0] = '╚';
            for (int i = 1; i < n + 1; i++) fieldMatrix[n + 1, i] = '═';
            fieldMatrix[n + 1, n + 1] = '╝';

            PrintMatrix(fieldMatrix);

            Console.Write("Введите строку с командами: ");
            string commands = Console.ReadLine();

            Steps steps = new Steps(robot.Forward);
            steps -= robot.Forward;
            int[] offset = new int[2] { 0, 0 };

            try
            {
                foreach (var ch in commands)
                {
                    switch (ch)
                    {
                        case 'F':
                            if (robot.Y + offset[1] + 1 > n) throw new ArgumentException("Выход за пределы поля!");
                            steps += robot.Forward;
                            offset[1] += 1;
                            fieldMatrix[n - robot.Y - offset[1] + 1, robot.X + 1 + offset[0]] = '+';
                            break;
                        case 'B':
                            if (robot.Y + offset[1] - 1 < 0) throw new ArgumentException("Выход за пределы поля!");
                            offset[1] -= 1;
                            steps += robot.Backward;
                            fieldMatrix[n - robot.Y - offset[1] - 1, robot.X + 1 + offset[0]] = '+';
                            break;
                        case 'R':
                            if (robot.X + offset[0] + 1 > n) throw new ArgumentException("Выход за пределы поля!");
                            offset[0] += 1;
                            steps += robot.Right;
                            fieldMatrix[n - robot.Y - offset[1], robot.X + 1 + offset[0] - 1] = '+';
                            break;
                        case 'L':
                            if (robot.X + offset[0] - 1 < 0) throw new ArgumentException("Выход за пределы поля!");
                            offset[0] -= 1;
                            steps += robot.Left;
                            fieldMatrix[n - robot.Y - offset[1], robot.X + 1 + offset[0] + 1] = '+';
                            break;
                        default:
                            break;
                    }
                }
            } catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            steps?.Invoke();

            Console.Clear();

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (i == n - robot.Y && j == robot.X + 1)
                    {
                        fieldMatrix[i, j] = '*';
                    }
                }
            }

            PrintMatrix(fieldMatrix);
        }
    }
}
