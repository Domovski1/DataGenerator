using System;
using System.Collections.Generic;

namespace DataGenerator
{
    class DataSource
    {
        public List<DataStructure> data = new List<DataStructure>();
        DataStructure person_1 = new DataStructure() { Surname = "Магомедов", Name = "Мухаммад", Lastname = "Абдулаевич", Age = 22, Gender = 'M', INN = "9911368825", Login = "login", Password = "Password", Mail = "domovski@mail.ru", Passport_Code = "8212", Passport_Number = "291333" };

        
        public List<string> Names = new List<string>();
        public List<string> Surnames = new List<string>();
        

        /// <summary>
        /// There filling names
        /// </summary>
        public void FillNames()
        {
            Names.Add("Али");
            Names.Add("Ахмад");
            Names.Add("Асхаб");
            Names.Add("Абдулла");
            Names.Add("Бадр");
            Names.Add("Бахлюль");
            Names.Add("Вагаб");
            Names.Add("Валид");
        }

        /// <summary>
        /// There filling surnames
        /// </summary>
        public void FillSurname()
        {
            Surnames.Add("Абдулаев");
            Surnames.Add("Ахмадов");
            Surnames.Add("Абакаров");
            Surnames.Add("Алиев");
            Surnames.Add("Будулаев");
            Surnames.Add("Давудов");
            Surnames.Add("Вадимов");
        }


        public Random rand = new Random();
        public void Start(int Count)
        {
            FillNames(); FillSurname();
            data.Add(person_1);

            for (int i = 0; i < Count; i++)
            {
                DataStructure user = new DataStructure()
                {
                    Name = Names[rand.Next(Names.Count)],
                    Surname = Surnames[rand.Next(Surnames.Count)],
                    Age = rand.Next(99),
                    Password = PasswordGenerator(),
                    Mail = "post" + Surnames[rand.Next(Surnames.Count)] + "@mail.ru",
                    Lastname = Surnames[rand.Next(Surnames.Count)] + "ич",
                    Login = Surnames[rand.Next(Surnames.Count)] + rand.Next(3000),
                    Passport_Code = "8212",
                    Passport_Number = rand.Next(10000, 99999).ToString(),
                    Gender = 'M',
                    INN = rand.Next(10000, 99999).ToString() + rand.Next(10000, 99999).ToString(),
                    PhoneNumber = "7 (" + rand.Next(100, 999).ToString() + ") " + rand.Next(100, 999).ToString() + rand.Next(99).ToString() + rand.Next(99).ToString()
                };

                
                data.Add(user);
            }
        }


        /// <summary>
        /// Метод, генерирующий пароль из 10 букв и цифр
        /// </summary>
        /// <returns>Пароль</returns>
        public string PasswordGenerator()
        {
            string alphabet = "QWERTYUIOPASDFGHJKLMNBVCXZ1234567890qwertyuioplkjhgfdsazxcvbnm";
            string password = "";
            for (int i = 0; i < 10; i++)
            {
                password += alphabet[rand.Next(alphabet.Length)];
            }

            return password;
        }
    }
}
