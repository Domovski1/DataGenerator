using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;

namespace DataGenerator
{
    class Program
    {
        public static DataSource source = new DataSource();
        static void Main(string[] args)
        {
            Console.WriteLine($"Выберите, в каком формате вам нужны данные: \n1) .csv \n2) .txt \n3) .json \n4) .xml");

            Console.WriteLine();
            try
            {
                string UserChoose = Console.ReadLine();
                Console.WriteLine("Какое количество данных вам нужно?");
                int Count = int.Parse(Console.ReadLine());

                switch (UserChoose)
                {
                    case "1":
                        To_CsvOrTxt(Convert.ToInt32(UserChoose), Count);
                        Console.WriteLine("Файл сохранён на рабочем столе под названием: data.csv");
                        break;
                    case "2":
                        To_CsvOrTxt(Convert.ToInt32(UserChoose), Count);
                        Console.WriteLine("Файл сохранён на рабочем столе под названием: data.txt");
                        break;
                    case "3":
                        To_json(Count);
                        Console.WriteLine("Файл сохранён на рабочем столе под названием: data.json");
                        break;
                    case "4":
                        xml_serializer();
                        Console.WriteLine("Файл сохранён на рабочем столе под названием: data.xml");
                        break;
                    default:
                        Console.WriteLine("Вы выбрали что-то другое");
                        break;
                }


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
        /// Сохраняет данные в формате .csv или .txt
        /// </summary>
        public static void To_CsvOrTxt(int UserChoice, int CountOfData)
        {
            // Присвоение файлу формата в зависимости от выбора пользователя
            string FileFormat;
            if (UserChoice == 1)
                FileFormat = ".csv";
            else
                FileFormat = ".txt";

            using (FileStream stream = new FileStream($@"C:\Users\{Environment.UserName}\Desktop\data{FileFormat}", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {

                    source.Start(CountOfData);
                    var service = source.data;

                    //Название заголовков
                    writer.WriteLine("Имя; Отчество; Возраст; Лoгин; Пароль; Почта; Пол; Серия паспорта; Номер паспорта; ИНН; Номер телефона;");

                    foreach (var item in service)
                    {
                        writer.WriteLine($"{item.Name}; {item.Surname}; {item.Age}; {item.Login}; {item.Password}; {item.Mail}; {item.Gender}; {item.Passport_Code}; {item.Passport_Number}; {item.INN}; {item.PhoneNumber};");
                    }
                }
            }
        }


        /// <summary>
        /// Генерирует файл в формате .json
        /// </summary>
        /// <param name="Count">Количество строк, которые будут сформированы</param>
        public static void To_json(int Count)
        {
            source.Start(Count);
            var data = source.data;

            var option = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };

            string str = JsonSerializer.Serialize<List<DataStructure>>(data, option);

            File.WriteAllText($@"C:\Users\{Environment.UserName}\Desktop\data.json", str);
        }

        private static void xml_serializer()
        {
            source.Start(5);
            var data = source.data;
            XmlSerializer formatter = new XmlSerializer(typeof(DataStructure));
            using (FileStream fs = new FileStream($@"C:\Users\{Environment.UserName}\Desktop\data.xml", FileMode.OpenOrCreate))
            {
                foreach (var item in data)
                {

                    formatter.Serialize(fs, item);

                }
            }
        }
        
    }
}
