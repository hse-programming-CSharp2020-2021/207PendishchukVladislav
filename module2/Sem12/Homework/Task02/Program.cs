using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] textParts = StringAbbreviation.ValidatedSplit(text, ';');

            for (int i = 0; i < textParts.Length; i++)
            {
                if (textParts[i] == null)
                {
                    Console.WriteLine("Неверный формат строки!");
                    return;
                }
                textParts[i] = StringAbbreviation.Abbrevation(textParts[i]);
                Console.WriteLine(textParts[i]);
            }
        }
    }
}
