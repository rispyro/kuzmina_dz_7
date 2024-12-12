using System;
using System.IO;
using tumakov_lab_7;
namespace Tumakov_lab_7
{
    internal class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();

            Console.ReadKey();
        }
        static void Task1()
        {
            Console.WriteLine("Упражнение 8.1");
            //В класс банковский счет, созданный в упражнениях 7.1 - 7.3 добавить
            //метод, который переводит деньги с одного счета на другой.У метода два параметра: ссылка
            //на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
            BankAccount account1 = new BankAccount(1234567.8m, AccountType.Saving);
            BankAccount account2 = new BankAccount(1.9m, AccountType.Current);
            Console.WriteLine(account1.AccountDetails());
            Console.WriteLine(account2.AccountDetails());

            Console.Write("введите сумму для перевода: ");
            string output = Console.ReadLine();
            if (decimal.TryParse(output, out decimal value))
            {
                account1.Transfer(account2, value);
            }
            else
            {
                Console.WriteLine("Вы неверно ввели данные.");
            }
            Console.WriteLine(account1.AccountDetails());
            Console.WriteLine(account2.AccountDetails());
        }
        static void Task2()
        {
            Console.WriteLine("\nУпражнение 8.2");
            //Реализовать метод, который в качестве входного параметра принимает
            //строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            //Протестировать метод.
            Console.WriteLine("Пример преобразования: ");
            string example = "мяу мяу";
            string reversedExample = Reverse(example);
            Console.WriteLine($"Исходная строка: {example}");
            Console.WriteLine($"Преобразованная строка: {reversedExample}");

            Console.Write("Введите строку для преобразования: ");
            string input = Console.ReadLine();
            string output = Reverse(input);
            Console.WriteLine($"Преобразованная строка: {output}");
        }
        static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        static void Task3()
        {
            Console.WriteLine("\nУпражнение 8.3");
            //Написать программу, которая спрашивает у пользователя имя файла.Если
            //такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            //работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            //буквами.
            Console.Write("Введите имя файла, который хотите найти: ");
            string inputFile = $"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\{Console.ReadLine()}";
            if (File.Exists(inputFile))
            {
                string input = File.ReadAllText(inputFile);
                string output = $"..\\..\\..\\output.txt";
                File.WriteAllText(output, GetUpper(input));
                Console.WriteLine("Регистр изменён, проверьте в файле output.txt");
            }
            else
            {
                Console.WriteLine("Файла с таким именем нет.");
            }
        }
        static string GetUpper(string input)
        {
            return input.ToUpper();
        }
        static void Task4()
        {

        }
        static void Task5()
        {
            Console.WriteLine("\nДомашнее задание 8.1");
            //Работа со строками.Дан текстовый файл, содержащий ФИО и e-mail
            //адрес.Разделителем между ФИО и адресом электронной почты является символ #:
            //Иванов Иван Иванович # iviviv@mail.ru
            //Сформировать новый файл, содержащий список адресов электронной почты.
            //Предусмотреть метод, выделяющий из строки адрес почты. Методу в
            //качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:
            //public void SearchMail(ref string s).
            string inputFile2 = $"..\\..\\..\\inputemail.txt";
            string outputFile2 = $"..\\..\\..\\outputemail.txt";

            if (File.Exists(inputFile2))
            {
                string[] lines = File.ReadAllLines(inputFile2);
                using (StreamWriter writer = new StreamWriter(outputFile2))
                {
                    foreach (string line in lines)
                    {
                        string emailLine = line;
                        SearchMail(ref emailLine);
                        writer.WriteLine(emailLine); 
                    }
                }
                Console.WriteLine("Адреса электронной почты записаны в файл outputemail.txt.");
            }
            else
            {
                Console.WriteLine("Файла с таким именем нет.");
            }
        }
        /// <summary>
        /// метод принимает строку по ссылке и ищет символ #
        /// </summary>
        /// <param name="s"></param>
        static void SearchMail(ref string s)
        {
            int separatorIndex = s.IndexOf('#'); 
            if (separatorIndex != -1 && separatorIndex + 1 < s.Length)
            {
                s = s.Substring(separatorIndex + 1).Trim(); 
            }
            else
            {
                s = string.Empty; 
            }
        }
        static void Task6()
        {

        }
    }
}
