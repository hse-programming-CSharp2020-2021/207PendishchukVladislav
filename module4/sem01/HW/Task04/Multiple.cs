using System;
using System.Collections.Generic;
using System.Text;

namespace Task04
{
    [Serializable]  // атрибут сериализации
    public class Multiple
    {
        public string name;    // название делителя
        public int divisor;    // значение делителя
        public int[] numbers;     // массив чисел, кратных divisor

        public override string ToString()
        {
            string mom = "Делитель: " + divisor + " - " + name + "\r\nКратные: ";

            foreach (int m in numbers)
                mom += m + "  ";

            return mom;
        }

        public Multiple(int div, int[] ar)
        {
            if (div <= 0 || div > 9)
                throw new Exception("Неверно выбран делитель!");

            divisor = div;

            switch (div)
            {
                case 1: name = "один"; break;
                case 2: name = "два"; break;
                case 3: name = "три"; break;
                case 4: name = "четыре"; break;
                case 5: name = "пять"; break;
                case 6: name = "шесть"; break;
                case 7: name = "семь"; break;
                case 8: name = "восемь"; break;
                case 9: name = "девять"; break;
            }

            int[] temp = new int[ar.Length];
            int numb = 0;

            for (int i = 0; i < ar.Length; i++) 
                if (ar[i] % div == 0) temp[numb++] = ar[i];

            numbers = new int[numb];
            Array.Copy(temp, numbers, numb);
        }

        public Multiple() { }
    }
}
