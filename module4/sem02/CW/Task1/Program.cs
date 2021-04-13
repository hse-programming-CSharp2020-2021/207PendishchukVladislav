using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Task1
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; set; }
        public Human(string name)
        {
            this.Name = name;
        }
    }

    [DataContract]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
    }

    [DataContract]
    public class Dept
    {
        [DataMember]
        public string DeptName { get; set; }

        List<Human> staff;

        [DataMember]
        public List<Human> Staff { get { return staff; } set { staff = value; } }
        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            staff = new List<Human>(staffList);
        }
    }

    [DataContract]
    public class University
    {
        [DataMember]
        public string UniversityName { get; set; }
        [DataMember]
        public List<Dept> Departments { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            University HSE = new University();
            HSE.UniversityName = "NRU HSE";

            Human[] deptStaff = { new Professor("Ivanov"),
                      new Professor("Petrov")
                    };

            Dept SE = new Dept("SE", deptStaff);
            HSE.Departments = new List<Dept>();
            HSE.Departments.Add(SE);

            University MSU = new University();
            MSU.UniversityName = "MSU";

            Human[] deptStaffM = { new Professor("Ivanov"),  new Professor("Chizov"),
                      new Professor("Petrov")
                    };

            Dept SEM = new Dept("SEM", deptStaffM);
            MSU.Departments = new List<Dept>();
            MSU.Departments.Add(SEM);

            University[] universities = new University[] { HSE, MSU };

            DataContractSerializer serializer = new DataContractSerializer(typeof(University[]), new Type[] { typeof(Human), typeof(Professor), typeof(Dept) });

            using (Stream file = new FileStream("ser.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.WriteObject(file, universities);
            }

            // Десериализация
            University[] deserial;

            using (Stream file = File.OpenRead("ser.xml"))
            {
                deserial = (University[])serializer.ReadObject(file);
                Console.WriteLine("XML - " + deserial[0].UniversityName);
                Console.WriteLine("XML - " + deserial[1].UniversityName);
            }

            foreach (Dept d in deserial[0].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }

            foreach (Dept d in deserial[1].Departments)
                foreach (Human h in d.Staff)
                {
                    if (h is Professor)
                        Console.WriteLine(d.DeptName + " prof.: " + h.Name);
                }

            Console.ReadKey();
        }
    }
}