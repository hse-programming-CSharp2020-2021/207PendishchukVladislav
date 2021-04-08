using System;
using System.IO;
using System.Xml.Serialization;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Multiple row;
            int size = 0;
            do
                Console.Write("Введите размер генеральной совокупности: ");
            while (!int.TryParse(Console.ReadLine(), out size) | size < 1);

            Random gen = new Random(5);
            int[] data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = gen.Next(0, 100);
                Console.Write(data[i] + "  ");
            }

            Console.WriteLine();

            using (FileStream stream = new FileStream("data.xml", FileMode.Create, FileAccess.ReadWrite))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Multiple));
                do
                {
                    int div;
                    do
                    {
                        do Console.Write("Введите делитель: ");
                        while (!int.TryParse(Console.ReadLine(), out div));

                        try
                        {
                            row = new Multiple(div, data);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Нужен делитель от 1 до 9!");
                            continue;
                        }
                    }
                    while (true);

                    xmlSerializer.Serialize(stream, row);
                    stream.Flush();

                    Console.WriteLine("\nДля чтения файла - клавиша ESC");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                stream.Position = 0;
                row = (Multiple)xmlSerializer.Deserialize(stream);
                Console.WriteLine(row.ToString());
            }
        }
    }
}
