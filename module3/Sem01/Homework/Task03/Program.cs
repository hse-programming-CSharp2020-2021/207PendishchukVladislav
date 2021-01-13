using System;

namespace ConsoleApp12
{
    delegate double delegateConvertTemperature(double n);

    class TemperatureConvertImp
    {
        public double CelciusToFahrenheit(double tempC) => (9 * tempC) / 5 + 32;
        public double FahrenheitToCelcius(double tempF) => (5 * (tempF - 32)) / 9;
    }

    class StaticTempConverters
    {
        static public double CelciusToKelvin(double tempC) => tempC + 273.15;
        static public double CelciusToRankin(double tempC) => 9*(tempC + 273.15)/5;
        static public double CelciusToReaumur(double tempC) => tempC/5 * 4;
        static public double KelvinToCelsius(double tempK) => tempK - 273.15;
        static public double RankinToCelsius(double tempR) => (tempR - 491.67) / 9 * 5;
        static public double ReaumurToCelsius(double tempRe) => tempRe / 4 * 5;
    }

    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConvertImp dummy = new TemperatureConvertImp();
            delegateConvertTemperature[] dels = new delegateConvertTemperature[] 
            { dummy.CelciusToFahrenheit, dummy.FahrenheitToCelcius, StaticTempConverters.CelciusToKelvin, 
                StaticTempConverters.CelciusToRankin, StaticTempConverters.CelciusToReaumur };

            double tempC = -10.5;
            double tempF = 40.5;

            Console.WriteLine($"{tempC} degrees Celcius to Fahrenheit: {dels[0]?.Invoke(tempC)}F");
            Console.WriteLine($"{tempF} degrees Fahrenheit to Celcius: {dels[1]?.Invoke(tempC)}C");

            Console.WriteLine();
            do
            {
                Console.Write("Enter the temperature in C: ");
            } while (!double.TryParse(Console.ReadLine(), out tempC));

            Console.WriteLine();
            Console.WriteLine($"{tempC} degrees Celcius to Fahrenheit: {dels[0]?.Invoke(tempC)}F");
            Console.WriteLine($"{tempC} degrees Celcius to Kelvin: {dels[2]?.Invoke(tempC)}K");
            Console.WriteLine($"{tempC} degrees Celcius to Rankin: {dels[3]?.Invoke(tempC)}R");
            Console.WriteLine($"{tempC} degrees Celcius to Reaumur: {dels[4]?.Invoke(tempC)}Re");
        }
    }
}
