using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    [Serializable, DataContract]
    public class ConsoleSimbolStruct
    {
        [DataMember]
        protected char simb;
        [DataMember]
        protected int x;
        [DataMember]
        protected int y;

        public char Simb
        {
            get => simb;
            set => simb = value;
        }

        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }

        public ConsoleSimbolStruct(char simb, int x, int y) {
            this.simb = simb;
            this.x = x;
            this.y = y;
        }

        public ConsoleSimbolStruct() { }

        public override string ToString()
        {
            return $"Char: {simb}, X: {x}, Y: {y}";
        }
    }

    public enum Color
    {
        Red,
        Blue,
        Yellow,
        Orange
    }

    [Serializable, DataContract]
    public class ColorConsoleSimbolStruct : ConsoleSimbolStruct
    {
        [DataMember]
        Color color;

        public Color Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        public ColorConsoleSimbolStruct() : base() { }

        public ColorConsoleSimbolStruct(char simb, int x, int y, Color color) : base(simb, x, y)
        {
            this.color = color;
        }

        public override string ToString()
        {
            return $"Char: {simb}, X: {x}, Y: {y}, color: {color}";
        }
    }

    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            ConsoleSimbolStruct[] array = new ConsoleSimbolStruct[10];

            for (int i = 0; i < array.Length; i++)
            {
                int typeInt = rand.Next(0, 2);
                switch (typeInt)
                {
                    case 0:
                        array[i] = new ConsoleSimbolStruct((char)rand.Next(33, 127), rand.Next(0, 41), rand.Next(0, 41));
                        break;
                    case 1:
                        array[i] = new ColorConsoleSimbolStruct((char)rand.Next(33, 127), rand.Next(0, 41), rand.Next(0, 41), (Color)rand.Next(0, 4));
                        break;
                }
            }

            BinaryFormatter formatter = new BinaryFormatter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConsoleSimbolStruct[]), new Type[] { typeof(ColorConsoleSimbolStruct) });
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(ConsoleSimbolStruct[]), new Type[] { typeof(ColorConsoleSimbolStruct) });

            using (Stream fs = new FileStream("ser.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fs, array);
            }

            using (Stream fs = new FileStream("ser.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSerializer.Serialize(fs, array);
            }

            File.WriteAllText("ser.json", JsonSerializer.Serialize<ConsoleSimbolStruct[]>(array));

            using (Stream fs = new FileStream("serCon.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                dataContractSerializer.WriteObject(fs, array);
            }

            ConsoleSimbolStruct[][] deser = new ConsoleSimbolStruct[4][];

            using (Stream file = File.OpenRead("ser.bin"))
            {
                deser[0] = (ConsoleSimbolStruct[])formatter.Deserialize(file);
            }

            using (Stream file = File.OpenRead("ser.xml"))
            {
                deser[1] = (ConsoleSimbolStruct[])xmlSerializer.Deserialize(file);
            }

            deser[2] = JsonSerializer.Deserialize<ConsoleSimbolStruct[]>(File.ReadAllText("ser.json"));

            using (Stream file = File.OpenRead("serCon.xml"))
            {
                deser[3] = (ConsoleSimbolStruct[])dataContractSerializer.ReadObject(file);
            }

            foreach (var symArray in deser)
            {
                foreach (var sym in symArray)
                {
                    Console.WriteLine(sym);
                }
                Console.WriteLine();
            }
        }
    }
}
