using System;
using System.IO;

namespace DataGenerator
{
    class Program
    {
        public static DataSource source = new DataSource();
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите, в каком формате вам нужны данные: ");
            Console.WriteLine("1) .csv");
            Console.WriteLine("2) .txt");
            Console.WriteLine("3) .json");
            Console.WriteLine("4) .xml");
            Console.WriteLine("5) .excel");
            Console.WriteLine("6) .pdf");
            Console.WriteLine();
            try
            {
                string UserChoose = Console.ReadLine();

                switch (UserChoose)
                {
                    case "1":
                        To_CSV();
                        //Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Файл сохранён на рабочем столе под названием: data.csv");
                        break;
                    case "2":
                        To_Txt();
                        Console.WriteLine("Файл сохранён на рабочем столе под названием: data.txt");
                        break;
                    default:
                        Console.WriteLine("Вы выбрали что-то другое");
                        break;
                }


                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                Console.ReadLine();

            }
        }


        /// <summary>
        /// Сохраняет данные в формате .csv
        /// </summary>
        public static void To_CSV()
        {
            using (FileStream stream = new FileStream(@"C:\Users\62427\Desktop\data.csv", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {

                    source.Start();
                    var service = source.data;

                    //Название заголовков
                    writer.WriteLine("Имя; Отчество; Возраст; Лoгин; Пароль; Почта; Пол; Серия паспорта; Номер паспорта; ИНН; Номер телефона;");

                    foreach (var item in service)
                    {
                        writer.WriteLine($"{item.Name}; {item.Surname}; {item.Age}; {item.Login}; {item.Password}; {item.Mail}; {item.Gender}; {item.Passport_Code}; {item.Passport_Number}; {item.INN}; {item.PhoneNumber};");
                    }
                    ;
                }
            }
        } // Можно будет совместить оба варианта (.ксв и .тхт) к одному
        
        
        public static void To_Txt()
        {
            using (FileStream stream = new FileStream(@"C:\Users\62427\Desktop\data.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    source.Start();
                    var service = source.data;

                    //Название заголовков
                    writer.WriteLine("Имя; Отчество; Возраст; Лoгин; Пароль; Почта; Пол; Серия паспорта; Номер паспорта; ИНН; Номер телефона;");

                    foreach (var item in service)
                    {
                        writer.WriteLine($"{item.Name}, {item.Surname}, {item.Age}, {item.Login}, {item.Password}, {item.Mail}, {item.Gender}, {item.Passport_Code}, {item.Passport_Number}, {item.INN}, {item.PhoneNumber},");
                        
                    }

                }
            }
        }
    }
}
