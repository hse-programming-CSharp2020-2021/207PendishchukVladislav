using System;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> exprStack = new Stack<char>();

            string expression = Console.ReadLine();

            foreach (var ch in expression)
            {
                switch (ch)
                {
                    case '{':
                    case '(':
                    case '[':
                        exprStack.Push(ch);
                        break;
                    case '}':
                        if (exprStack.Peek() == '{')
                        {
                            exprStack.Pop();
                        }
                        break;
                    case ')':
                        if (exprStack.Peek() == '(')
                        {
                            exprStack.Pop();
                        }
                        break;
                    case ']':
                        if (exprStack.Peek() == '[')
                        {
                            exprStack.Pop();
                        }
                        break;
                }
            }

            if (exprStack.Count == 0) Console.WriteLine("Correct");
            else Console.WriteLine("Incorrect");
        }
    }
}
