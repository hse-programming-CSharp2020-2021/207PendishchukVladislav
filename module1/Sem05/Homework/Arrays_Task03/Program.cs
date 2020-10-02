using System;

/*
3.1. Написать метод, формирующий и возвращающий массив из N членов разложения в ряд функции sin(1):  
	sin(x)= x - x3/3! + x5/5! - ... 
Параметр N – число требуемых членов ряда.
3.2. Написать метод для вычисления sin(х) для заданного х с использованием массива членов ряда sin(1). 
Параметры: ссылка на массив разложения sin(1) и аргумент х.
 
3.3. В основной программе ввести значение N вычислить массив sin(1). Вводя, последовательно вводя, 
значения х, вычислять sin(х) как с помощью созданного метода, так и с использованием библиотечного 
метода Math.Sin(). Сравнить результаты. 
*/
class Program
{
    // Метод, считающий значение функции y = 1/x!
    static double factorialDiv(int x)
    {
        double prevFac = 0;
        double fac = 1;
        while (x > 0 && fac != prevFac)
        {
            prevFac = fac;
            fac *= 1 / (double)x;
            x -= 1;
        }

        return prevFac;
    }
    

    // Метод, формирующий массив с членами разложения функции sin(1) по ряду.
    static double[] seriesSin(int N)
    {
        double[] sinArray = new double[N];
        for (int i = 0; i < N; i++)
        {
            sinArray[i] = Math.Pow(-1, i) * factorialDiv(2 * (i + 1) - 1);
        }

        return sinArray;
    }


    // Метод, вычисляющий синус по разложению sin(1) по ряду.
    static double calculateSin(double x, ref double[] sinArray)
    {
        double prevSum;
        double sum = 0;
        for (int i = 0; i < sinArray.Length; i++)
        {
            prevSum = sum;
            sum += Math.Pow(x, 2 * (i + 1) - 1) * sinArray[i];

            if (prevSum == sum) break;
        }

        return sum;
    }


    static void Main(string[] args)
    {
        double angle, x;

        do
        {
            Console.Write("Введите значение угла: ");
        }
        while (!double.TryParse(Console.ReadLine(), out angle) || angle <= 0);

        x = angle % (2 * Math.PI);
        double[] series = seriesSin(20);

        Console.Write(Environment.NewLine + $"По ряду: {calculateSin(x, ref series)}, по функции: {Math.Sin(angle)}");
        Console.ReadKey();
    }
}