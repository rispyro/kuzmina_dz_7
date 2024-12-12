using System;
using System.Collections.Generic;
using System.Linq;

namespace file_dz_7
{
    internal class Program
    {
        static void Main()
        {
            ///Самые главные
            Employee timur = new Employee("Тимур", "Генеральный директор", null);
            Employee rashid = new Employee("Рашид", "Финансовый директор", timur);
            Employee oilham = new Employee("О Ильхам", "Директор по оптимизации", timur);
            ///Отдел финансов
            Employee lucas = new Employee("Лукас", "Бухгалтер", rashid);
            ///Начальники IT
            Employee orkadiy = new Employee("Оркадий", "Начальник IT", oilham);
            Employee volodya = new Employee("Володя", "Зам.начальника IT", orkadiy);
            ///системщики
            Employee ilshat = new Employee("Ильшат", "Системный администратор", orkadiy);
            Employee ivanch = new Employee("Иваныч", "Зам.системного адмнинистратора", ilshat);
            Employee ilya = new Employee("Илья", "Сотрудник-системщик", ivanch);
            Employee vitya = new Employee("Витя", "Сотрудник-системщик", ivanch);
            Employee zhenya = new Employee("Женя", "Сотрудник-системщик", ivanch);
            ///разработчики
            Employee sergey = new Employee("Сергей", "Главный Разработчик", orkadiy);
            Employee leysan = new Employee("Ляйсан", "Зам.Главного разработчика", sergey);
            Employee marat = new Employee("Марат", "Сотрудник-разработчик", leysan);
            Employee dina = new Employee("Дина", "Сотрудник-разработчик", leysan);
            Employee ildar = new Employee("Ильдар", "Сотрудник-разработчик", leysan);
            Employee anton = new Employee("Антон", "Сотрудник-разработчик", leysan);

            List<Employee> employees = new List<Employee> { timur, rashid, lucas, orkadiy, volodya, ilshat, sergey, oilham, ilya, vitya, zhenya, marat, dina, ildar, anton, leysan};

            bool running = true;
            while (running)
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1 - Показать всех сотрудников");
                Console.WriteLine("2 - Выдать задачу");
                Console.WriteLine("exit - Выход из программы");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "exit")
                {
                    running = false;
                    continue;
                }
                switch (userInput)
                {
                    case "1":
                        DisplayEmployees(employees);
                        break;
                    case "2":
                        IssueTask(employees);
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }
        /// <summary>
        /// метод для вывода всех сотрудников конторы
        /// </summary>
        /// <param name="employees"></param>
        static void DisplayEmployees(List<Employee> employees)
        {
            Console.WriteLine("Список сотрудников:");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"Имя: {employee.Name}, Должность: {employee.Position}, Начальник: {employee.Manager?.Name ?? "Нет"}");
            }
        }
        /// <summary>
        /// метод позволяет пользователю выдавать задачи, проверяя, кто выдает задачу и кому она предназначена
        /// </summary>
        /// <param name="employees"></param>
        static void IssueTask(List<Employee> employees)
        {
            Console.WriteLine("Кто выдает задачу? (введите имя или 'exit' для выхода):");
            string issuerName = Console.ReadLine();
            if (issuerName.ToLower() == "exit")
                return;
            Employee issuer = employees.FirstOrDefault(e => e.Name.Equals(issuerName, StringComparison.CurrentCultureIgnoreCase));
            if (issuer == null)
            {
                Console.WriteLine("Сотрудник не найден. Попробуйте снова.");
                return;
            }
            Console.WriteLine("Кому выдается задача? (введите имя):");
            string assigneeName = Console.ReadLine();
            Employee assignee = employees.FirstOrDefault(e => e.Name.Equals(assigneeName, StringComparison.CurrentCultureIgnoreCase));
            if (assignee == null)
            {
                Console.WriteLine("Сотрудник не найден. Попробуйте снова.");
                return;
            }
            Console.WriteLine("Введите название задачи:");
            string taskName = Console.ReadLine();
            Task task = new Task(taskName, assignee);
            task.AssignTask(issuer);
        }
    }
}
