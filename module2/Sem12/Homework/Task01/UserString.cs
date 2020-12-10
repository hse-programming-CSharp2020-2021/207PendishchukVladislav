using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    class UserString
    {
        public string objectString;
        static Random gen = new Random();

        public UserString(int k, char minChar, char maxChar)
        {
            if (k < 0) throw new Exception("Аргумент метода должен быть положительным!");

            if (maxChar < minChar)
            {
                char c = minChar;
                minChar = maxChar;
                maxChar = c;
            }

            string line = String.Empty;
            for (int i = 0; i < k; i++) line += (char)gen.Next(minChar, maxChar + 1);
            objectString = line;
        }

        public void MoveOff(string s2)
        {
            string res = objectString;
            int index;

            for (int i = 0; i < s2.Length; i++)
                while ((index = res.IndexOf(s2[i])) >= 0)
                    res = res.Remove(index, 1);

            objectString = res;
        }
    }
}
