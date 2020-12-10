using System;
using System.Collections.Generic;
using System.Text;

namespace Task02
{
    class StringAbbreviation
    {
        // проверка, что строки состоят только из символов латинского алфавита
        // и пробелом
        public static bool Validate(string str)
        {
            char[] english = new char[53];
            english[0] = ' ';
            for (int i = 1; i < 27; i++)
            {
                english[i] = (char)('a' + i);
            }
            for (int i = 27; i < english.Length; i++)
            {
                english[i] = (char)('A' + i);
            }
            if (str.IndexOfAny(english) < 0) return false;
            return true;
        } 


        // получение массива строк
        // каждый элемент проверен на соответствие формату
        public static string[] ValidatedSplit(string str, char ch)
        {
            string[] output = null;
            output = str.Split(ch);
            foreach (string s in output)
            {
                if (!Validate(s)) return null;
            }
            return output;
        } // end of ValidatdSplit(string, char)


        // Обрезка строки по первому гласному
        public static string Shorten(string str)
        {
            char[] alph = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U' };
            int ind = str.IndexOfAny(alph);
            return str.Substring(0, ind + 1);
        } 
        
        
        // end of Shorten(string)
        // Метод создания аббревиатуры для ПОДстроки (в ней много слов)
        public static string Abbrevation(string str)
        {
            string output = String.Empty;
            if (str != String.Empty)
            {
                str = str.Trim(' ');
                string[] tmp = str.Split(' ');
                foreach (string s in tmp)
                {
                    string shortenS = Shorten(s);
                    FirstUpcase(ref shortenS);
                    output += shortenS;
                }
            }
            return output;
        } // end of Abbrevation(string)


        // Метод преобразования первого символа к заглавному
        public static void FirstUpcase(ref string str)
        {
            char[] chars = str.ToCharArray();
            str = str[0].ToString().ToUpper() + str.Substring(1).ToLower();
        } // end of FirstUpcase(ref string)

    }
}
