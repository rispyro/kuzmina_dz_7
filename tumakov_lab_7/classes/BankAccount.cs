using System;

namespace tumakov_lab_7
{
    /// <summary>
    /// Перечислимый тип данных, отображающий виды банковского счета
    /// </summary>
    enum AccountType { Current, Saving }
    /// <summary>
    /// Класс Счёт в банке
    /// </summary>
    internal class BankAccount
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        private Guid accountNumber;

        /// <summary>
        /// Баланс
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Тип банковского счета
        /// </summary>
        private AccountType type;

        /// <summary>
        /// Конструктор для инициализации счета
        /// </summary>
        /// <param name="accBalance">Баланс</param>
        /// <param name="accType">Тип счета</param>
        public BankAccount(decimal accBalance, AccountType accType)
        {
            accountNumber = Guid.NewGuid();
            balance = accBalance;
            type = accType;
        }
        /// <summary>
        /// Метод для снятия со счета
        /// </summary>
        /// <param name="output"></param>
        public void CheckOut(decimal output)
        {
            if (balance > output)
            {
                balance -= output;
            }
            else
            {
                Console.WriteLine("Недостаточно денег для снятия.");
                return;
            }
        }
        /// <summary>
        /// Метод для пополнения счета
        /// </summary>
        /// <param name="input"></param>
        public void CheckBalance(decimal input)
        {
            balance += input;
        }
        /// <summary>
        /// Для вывода информации о счете
        /// </summary>
        /// <returns>Строка с информацией о счете</returns>
        public string AccountDetails()
        {
            return $"Номер счета: {accountNumber}\nБаланс: {balance} руб.\nТип счета: {type}";
        }
        public void Transfer(BankAccount account, decimal amount)
        {
            if (balance>=amount)
            { 
                this.CheckOut(amount);
                account.CheckBalance(amount);
            }
            else
            {
                Console.WriteLine("Недостаточно денег для перевода.");
            }
        }
    }
}
