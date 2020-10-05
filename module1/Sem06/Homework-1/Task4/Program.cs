using System;

namespace Task4
{
    class Program
    {
        // Метод, вычисляющий определитель переданной матрицы 2 на 2.
        static double Determinant2x2(double[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        // Метод, вычисляющий определитель переданной матрицы 3 на 3.
        static double Determinant3x3(double[,] matrix)
        {
            double[,] minor1 = { { matrix[1, 1], matrix[1, 2] }, { matrix[2, 1], matrix[2, 2] } };
            double[,] minor2 = { { matrix[1, 0], matrix[1, 2] }, { matrix[2, 0], matrix[2, 2] } };
            double[,] minor3 = { { matrix[1, 0], matrix[1, 1] }, { matrix[2, 0], matrix[2, 1] } };
            double num1 = matrix[0, 0] * Determinant2x2(minor1);
            double num2 = matrix[0, 1] * Determinant2x2(minor2);
            double num3 = matrix[0, 2] * Determinant2x2(minor3);
            return num1 - num2 + num3;
        }

        static void Main(string[] args)
        {
        }
    }
}
