using System;

namespace Task06
{
    class Program
    {
        // Метод, вычисляющий определитель переданной матрицы 2 на 2.
        static int Determinant2x2(int[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        // Метод, вычисляющий определитель переданной матрицы 3 на 3.
        static int Determinant3x3(int[,] matrix)
        {
            int[,] minor1 = { { matrix[1, 1], matrix[1, 2] }, { matrix[2, 1], matrix[2, 2] } };
            int[,] minor2 = { { matrix[1, 0], matrix[1, 2] }, { matrix[2, 0], matrix[2, 2] } };
            int[,] minor3 = { { matrix[1, 0], matrix[1, 1] }, { matrix[2, 0], matrix[2, 1] } };
            int num1 = matrix[0, 0] * Determinant2x2(minor1);
            int num2 = matrix[0, 1] * Determinant2x2(minor2);
            int num3 = matrix[0, 2] * Determinant2x2(minor3);
            return num1 - num2 + num3;
        }

        // Метод, генерирующий матрицу 3 на 6 со случайными целыми значениями элементов из интервала [0, 20].
        static int[,] GenerateMatrix()
        {
            Random rand = new Random();
            int[,] matrix = new int[3, 6];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++) matrix[i, j] = rand.Next(0, 21);
            }

            return matrix;
        }

        static void Main(string[] args)
        {

            // Генерация матрицы.
            int[,] matrix = GenerateMatrix();

            // Вывод сгенерированной матрицы.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(matrix[i, j] + " \t");
                }
                Console.Write(Environment.NewLine);
            }

            // Разбиение матрицы на правую и левую подматрицу размера 3 на 3.
            int[,] submatrixLeft = { { matrix[0, 0], matrix[0, 1], matrix[0, 2] }, { matrix[1, 0], matrix[1, 1], matrix[1, 2] }, { matrix[2, 0], matrix[2, 1], matrix[2, 2] } };
            int[,] submatrixRight = { { matrix[0, 3], matrix[0, 4], matrix[0, 5] }, { matrix[1, 3], matrix[1, 4], matrix[1, 5] }, { matrix[2, 3], matrix[2, 4], matrix[2, 5] } };

            // Массив, сохраняющий значения определителя левой (0) и правой (1) подматриц.
            int[] determinantArray = new int[2];

            // Вычисление определителей.
            determinantArray[0] = Determinant3x3(submatrixLeft);
            determinantArray[1] = Determinant3x3(submatrixRight);

            // Вывод определителей.
            Console.WriteLine($"\n{determinantArray[0]}\t{determinantArray[1]}");
        }
    }
}