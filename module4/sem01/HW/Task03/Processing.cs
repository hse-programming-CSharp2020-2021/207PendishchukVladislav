using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task03
{
    delegate void QDelegate(Quadratic quadraticEq);

    class Processing
    {
        static Random rand = new Random();

        public static void SolutionReal(Quadratic eq)
        {
            if (eq.Discriminant < 0) return;
            Console.WriteLine(eq.ToString() + "  дискриминант = " + eq.Discriminant);
            Console.WriteLine("\tКорни: Х1={0,3:g3}  \tX2={1,3:g3}", eq.X1, eq.X2);
        }

        public static void PrintEq(Quadratic eq)
        {
            Console.WriteLine(eq.ToString() + "  дискриминант = " + (eq.Discriminant).ToString("g3"));
        }

        static public void WriteFile(string nameFile, int numb)
        {
            using (FileStream streamOut = new FileStream(nameFile, FileMode.Create))
            {
                XmlSerializer formatOut = new XmlSerializer(typeof(Quadratic[]));

                Quadratic[] arr = new Quadratic[numb];
                for (int j = 0; j < numb; j++)
                {
                    try
                    {
                        arr[j] = new Quadratic(rand.Next(-10, 11), rand.Next(-10, 11), rand.Next(-10, 11));
                    } catch
                    {
                        j--; continue;
                    }
                }

                formatOut.Serialize(streamOut, arr);
            }
        }

        public static void Process(string fileName, QDelegate qDel)
        {
            using (FileStream streamIn = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer formatIn = new XmlSerializer(typeof(Quadratic[]));
                Quadratic[] eq = (Quadratic[])formatIn.Deserialize(streamIn);
                foreach (var q in eq)
                {
                    qDel(q);
                }
            }
        }
    }
}
