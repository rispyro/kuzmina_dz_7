using System;
namespace file_dz_7
{
    /// <summary>
    /// Класс для выдачи заданий
    /// </summary>
    class Task
    {
        public string Name { get; }
        public Employee AssignedTo { get; }
        public Task(string name, Employee assignedTo)
        {
            Name = name;
            AssignedTo = assignedTo;
        }
        /// <summary>
        /// метод для принятия/отклонения задачи
        /// </summary>
        /// <param name="issuer"></param>
        public void AssignTask(Employee issuer)
        {
            Console.WriteLine($"Задача: {Name}");
            if (AssignedTo.AcceptTask(Name, issuer))
            {
                Console.WriteLine($"{AssignedTo.Name} принял задачу «{Name}».");
            }
            else
            {
                Console.WriteLine($"{AssignedTo.Name} не принимает задачу «{Name}».");
            }
        }
    }
}
