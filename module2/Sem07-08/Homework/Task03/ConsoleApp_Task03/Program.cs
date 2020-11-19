using System;
using System.Collections.Generic;
using Employees;

namespace ConsoleApp_Task03
{
    class Program
    {
        // Метод, возвращающий случайную строку длиной от 3 до 9 символов.
        public static string RandomString()
        {
            Random rand = new Random();
            string result = "";
            int length = rand.Next(3, 10);
            for (int i = 0; i < length; i++)
            {
                result += (char) rand.Next('a', 'z');
            }

            return result;
        }

        static void Main(string[] args)
        {
            // Создание массива и заполнение его объектами случайным образом.
            Employee[] employees = new Employee[10];
            Random rand = new Random();
            for (int i = 0; i < employees.Length; i++)
            {
                int cntr = rand.Next(0, 2);
                if (cntr == 0) employees[i] = new SalesEmployee(RandomString(), (decimal)(rand.Next(0, 2000) + rand.NextDouble()), (decimal)(rand.Next(0, 500) + rand.NextDouble()));
                else if (cntr == 1) employees[i] = new PartTimeEmployee(RandomString(), (decimal)(rand.Next(0, 2000) + rand.NextDouble()), rand.Next(1, 30));
            }

            // Разделение массива по виду объекта.
            List<Employee> salesEmployees = new List<Employee>();
            List<Employee> partTimeEmployees = new List<Employee>();
            foreach (var employee in employees)
            {
                if (employee is SalesEmployee) salesEmployees.Add(employee);
                else partTimeEmployees.Add(employee);
            }

            // Сортировка списков по убыванию.
            salesEmployees.Sort(((employee, employee1) => employee.CalculatePay().CompareTo(employee1.CalculatePay())));
            salesEmployees.Reverse();
            partTimeEmployees.Sort(((employee, employee1) => employee.CalculatePay().CompareTo(employee1.CalculatePay())));
            partTimeEmployees.Reverse();

            // Вывод информации об объектах в массивах.
            Console.WriteLine("Sales employees: ");
            for (int i = 0; i < salesEmployees.Count; i++)
            {
                Console.WriteLine($"Employee {i + 1}: {salesEmployees[i].CalculatePay():f2}");
            }

            Console.WriteLine();
            Console.WriteLine("Part-time employees: ");
            for (int i = 0; i < partTimeEmployees.Count; i++)
            {
                Console.WriteLine($"Employee {i + 1}: {partTimeEmployees[i].CalculatePay():f2}");
            }
        }
    }
}
