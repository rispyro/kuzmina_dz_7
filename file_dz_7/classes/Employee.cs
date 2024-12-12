using System;
using System.Collections.Generic;

namespace file_dz_7
{
    /// <summary>
    /// Класс для работников конторы
    /// </summary>
    class Employee
    {
        public string Name { get; }
        public string Position { get; }
        public Employee Manager { get; }

        public Employee(string name, string position, Employee manager)
        {
            Name = name;
            Position = position;
            Manager = manager;
        }

        /// <summary>
        /// Метод для проверки, может ли текущий сотрудник принять задачу от другого сотрудника
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="issuer"></param>
        /// <returns></returns>
        public bool AcceptTask(string taskName, Employee issuer)
        {
            if (IsLowerPosition(issuer))
            {
                return false;
            }

            if (Position == "Генеральный директор")
            {
                return true;
            }
            if (Position == "Финансовый директор")
            {
                return issuer.Position == "Генеральный директор";
            }
            if (Position == "Начальник IT" || Position == "Зам.начальника IT")
            {
                return issuer.Position == "Генеральный директор";
            }
            if (Position == "Бухгалтер")
            {
                return issuer.Position == "Финансовый директор";
            }
            if (Position == "Системный администратор" || Position == "Главный Разработчик")
            {
                return issuer.Position == "Начальник IT" || issuer.Position == "Зам.начальника IT";
            }
            if (Position == "Зам.системного адмнинистратора")
            {
                return issuer.Position == "Системный администратор";
            }
            if (Position == "Сотрудник-системщик")
            {
                return issuer.Position == "Зам.системного адмнинистратора";
            }
            if (Position == "Зам.Главного разработчика")
            {
                return issuer.Position == "Главный Разработчик";
            }
            if (Position == "Сотрудник-разработчик")
            {
                return issuer.Position == "Зам.Главного разработчика";
            }
            return false;
        }
        /// <summary>
        /// Метод для проверки, ниже ли текущий сотрудник по статусу по отношению к другому
        /// </summary>
        /// <param name="issuer"></param>
        /// <returns></returns>
        private bool IsLowerPosition(Employee issuer)
        {
            List<string> hierarchy = new List<string>
        {
            "Сотрудник-разработчик",
            "Сотрудник-системщик",
            "Зам.системного адмнинистратора",
            "Зам.Главного разработчика",
            "Системный администратор",
            "Главный Разработчик",
            "Бухгалтер",
            "Зам.начальника IT",
            "Начальник IT",
            "Финансовый директор",
            "Генеральный директор"
        };
            int currentPositionIndex = hierarchy.IndexOf(Position);
            int issuerPositionIndex = hierarchy.IndexOf(issuer.Position);

            return issuerPositionIndex < currentPositionIndex;
        }
    }
}
