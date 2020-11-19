namespace Employees
{
    // Базовый класс сотрудников.
    public class Employee
    {
        // Поля класса - имя и базовый доход.
        public string name;
        protected decimal basepay;

        // Конструктор класса.
        public Employee(string name, decimal basepay)
        {
            this.name = name;
            this.basepay = basepay;
        }

        // Виртуальный метод, возвращающий месячный доход сотрудника.
        public virtual decimal CalculatePay()
        {
            return basepay;
        }
    }

    // Класс-наследник - сотрудник отдела продаж.
    public class SalesEmployee : Employee
    {
        // Поле класса - бонус за продажи.
        private decimal salesbonus;

        // Конструктор класса.
        public SalesEmployee(string name, decimal basepay,
            decimal salesbonus) : base(name, basepay)
        {
            this.salesbonus = salesbonus;
        }

        // Виртуальный метод, возвращающий месячный доход сотрудника.
        public override decimal CalculatePay()
        {
            return basepay + salesbonus;
        }
    }

    // Класс-наследник - внештатный сотрудник.
    public class PartTimeEmployee : Employee
    {
        // Поле класса - кол-во рабочих дней в месяц.
        private int workingDays;

        // Конструктор класса.
        public PartTimeEmployee(string name, decimal basepay, int workingDays) : base(name, basepay)
        {
            this.workingDays = workingDays;
        }

        // Виртуальный метод, возвращающий месячный доход сотрудника.
        public override decimal CalculatePay()
        {
            return workingDays * (basepay / 25);
        }
    }
}