using System;

namespace Task01
{
    class Birthday
    {
        // Закрытые поля - имя и дата рождения.
        string name;
        DateTime birthday;

        // Конструктор класса Birthday.
        public Birthday(DateTime birthday, string name)
        {
            this.name = name;
            this.birthday = birthday;
        }

        // Конструктор класса без параметров (по умолчанию).
        public Birthday()
        {
            this.name = "sample_name";
            this.birthday = new DateTime(1970, 1, 1);
        }
        
        /// <summary>
        /// Метод расчёта кол-ва дней до следующего дня рождения.
        /// </summary>
        /// <returns> Кол-во дней до дня рождения. </returns>
        int DaysUntilBirthday()
        {
            DateTime today = DateTime.Today;
            DateTime next = birthday.AddYears(today.Year - birthday.Year);

            if (next < today) next = next.AddYears(1);

            return (next - today).Days;
        }

        // Свойство - информация об объекте класса.
        public string GetInfo
        {
            get
            {
                return "Имя: " + this.name + ", дата рождения: " + this.birthday.ToString("dd-MM-yyyy") +
                       ", дней до дня рождения: " + DaysUntilBirthday();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthday;

            // Ввод имени.
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            // Ввод даты рождения
            do
            {
                Console.Write("Введите дату рождения в формате dd.mm.yyyy: ");
            } while (!DateTime.TryParse(Console.ReadLine(), out birthday));

            // Создание объекта.
            Birthday objBirthday = new Birthday(birthday, name);

            // Вывод информации об объекте.
            Console.WriteLine(objBirthday.GetInfo);
        }
    }
}
